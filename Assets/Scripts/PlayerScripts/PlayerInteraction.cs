using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private RaycastHit hit;
    private Ray playerRay;
    private int layerMask;
    [Tooltip("The canvas that appears to say stuff like 'Please press E to interact'")]
    [SerializeField]
    private GameObject interactText;
    [Tooltip("The parent of objects that can be interacted")]
    [SerializeField]
    private GameObject propParent;
    private bool isFull = false;
    private Rigidbody objectRigidbody;

    [Header("Plane Stats")]
    [SerializeField]
    private float planeSpeed;
    private GameObject dummyGameObject;
    private void Update()
    {
        PlayerRaycast();
    }
    public void PlayerRaycast()
    {
        //Create the ray that will be our players interaction ray
        playerRay.origin = gameObject.transform.position;
        playerRay.direction = gameObject.transform.TransformDirection(Vector3.forward);
        //Only interact with interactable objects. That is why specify a layer with bit mask
        layerMask = 1 << 8;
        //Check if the raycast is hit and if the hand is already full
        if(Physics.Raycast(playerRay.origin,playerRay.direction,out hit,5f, layerMask) && !isFull)
        {
            dummyGameObject = hit.collider.gameObject;
            //Activate the 'Please press "" to interact canvas
            interactText.SetActive(true);
            //If Key E is hold than carry the object with player on the raycast
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.GetComponent<SpecialKeyScript>())
                {
                    hit.collider.gameObject.GetComponent<SpecialKeyScript>().enabled = false;
                }

                if (hit.collider.gameObject.CompareTag("Plane"))
                {
                    hit.collider.gameObject.transform.forward = -gameObject.transform.forward;
                }
                else if (hit.collider.gameObject.CompareTag("Key"))
                {
                    hit.collider.gameObject.transform.forward = gameObject.transform.forward;
                }
                else if (hit.collider.gameObject.CompareTag("Rumba"))
                {
                    hit.collider.gameObject.transform.GetComponent<RumbaMovement>().enabled = false;
                    hit.collider.gameObject.transform.GetComponent<Collider>().isTrigger = false;
                }

                if (hit.collider.gameObject.transform.GetComponent<Rigidbody>())
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }
                hit.collider.gameObject.transform.parent = gameObject.transform;
                interactText.SetActive(false);
                isFull = true;
            }
            //Draw our player ray
            Debug.DrawRay(playerRay.origin,playerRay.direction,Color.red);
        }
        else if(isFull)
        {
            //Deactivate the canvas and draw the ray
            interactText.SetActive(false);
            Debug.DrawRay(playerRay.origin, playerRay.direction, Color.green);

            //Put the object back to the original prop parent and give back the rigidbody specifications. The hand is now empty 
            if (Input.GetKeyDown(KeyCode.E) || dummyGameObject.layer == 0)
            {
                isFull = false;
                //Debug.Log(dummyGameObject);
                if (dummyGameObject.CompareTag("Plane"))
                {
                    dummyGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    dummyGameObject.transform.GetComponent<Rigidbody>().velocity = playerRay.direction * planeSpeed;
                }
                else
                {
                    dummyGameObject.GetComponent<Rigidbody>().useGravity = true;
                    dummyGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
                dummyGameObject.transform.parent = propParent.transform;
            }
            
        }
        else
        {
            interactText.SetActive(false);
            Debug.DrawRay(playerRay.origin, playerRay.direction, Color.green);
        }
    }
}
