using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField]
    private GameObject fridgeDoor;
    [SerializeField]
    private GameObject interactionText;
    [SerializeField]
    private float openTheFridgeSpeed;
    [SerializeField]
    private Collider triggeCollider;
    [SerializeField]
    private float afterJumpScareClosingTime;
    [SerializeField]
    private float closeAngle;
    [Tooltip("Buraya jump scare'ın olacağı kapı açısı gerekiyor")]
    [SerializeField]
    private float jumpScareRotationTime;
    [SerializeField]
    private RumbaMovement jumpScareRumba;
   /* [SerializeField]
    private Collider doorCollider;*/
    [SerializeField]
    private GameObject backDoorAndShelves;

    private bool canOpenDoor = false;
    private bool isOpeningWithHand = false;
    private bool closingTime = false;
    private float timer = 0;
    private void Awake()
    {
        triggeCollider = transform.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        doorOpenWithHand();
        openRotate();
        closeRotate();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpenDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canOpenDoor)
        {
            canOpenDoor = false;
        }
    }

    public void doorOpenWithHand()
    {
        if (canOpenDoor)
        {
            interactionText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isOpeningWithHand = true;
                canOpenDoor = false;
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    public void openRotate()
    {
        if (isOpeningWithHand && fridgeDoor.transform.rotation.z > -200 / 360f)
        {
            fridgeDoor.transform.Rotate(0f,0f, openTheFridgeSpeed * Time.deltaTime);
            if (fridgeDoor.transform.rotation.z < -jumpScareRotationTime / 360f)
            {
                jumpScareRumba.WakeUp();
                jumpScareRumba.gameObject.transform.GetComponent<Rumba>().enabled = true;
            }
        }
        else if (Mathf.Clamp(fridgeDoor.transform.rotation.z, -200f/360f, 0f) == -200f / 360)
        {
            isOpeningWithHand = false;
            triggeCollider.enabled = false;
            closingTime = true;
        }
    }

    public void closeRotate()
    {
        if(closingTime && !isOpeningWithHand)
        {
            timer += Time.deltaTime * 1;
            if (timer >= afterJumpScareClosingTime)
            {
                if (fridgeDoor.transform.rotation.y < 0f)
                    fridgeDoor.transform.Rotate(0f,0f, -openTheFridgeSpeed * Time.deltaTime);
                else //if (Mathf.Clamp(fridgeDoor.transform.rotation.z, -200f/360f, 0f) == -200f / 360f)
                {
                    closingTime = false;
                    //doorCollider.enabled = true;
                    backDoorAndShelves.SetActive(false);
                }

            }
        }
    }
}
