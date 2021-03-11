using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private Ray keyRay;
    private RaycastHit keyHit;
    private int layerMask = 1 << 9;
    private GameObject dummyObject;
    private bool isOpen = false;

    [SerializeField]
    private GameObject doorToOpen;
    [SerializeField]
    private GameObject interactionText;

    private void Awake()
    {
        keyRay.origin = gameObject.transform.position;
        keyRay.direction = gameObject.transform.forward;
    }
    // Update is called once per frame
    void Update()
    {
        KeyRayCast();
    }

    public void KeyRayCast()
    {
        keyRay.origin = gameObject.transform.position;
        keyRay.direction = gameObject.transform.forward;
        Debug.DrawRay(keyRay.origin, keyRay.direction, Color.green);
        if (Physics.Raycast(keyRay.origin, keyRay.direction, out keyHit, 1.5f, layerMask))
        {
            dummyObject = keyHit.collider.gameObject;
            if(dummyObject == doorToOpen)
            {
                if (!isOpen)
                {
                    interactionText.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        isOpen = true;
                        doorToOpen.transform.GetComponent<Doors>().setOpen(true);
                        gameObject.layer = 0;
                    }
                }
                else
                {
                    interactionText.SetActive(false);
                }

                
            }
        }
    }


}
