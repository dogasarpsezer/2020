using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    [SerializeField]
    private Collider outsideTrigger;
    [SerializeField]
    private GameObject theLid;
    [SerializeField]
    private float lidSpeed;
    [SerializeField]
    private GameObject interactionText;
    [SerializeField]
    private GameObject interactionCloseText;

    private GameObject rumba;
    private bool canOpen = false;
    private bool openTheLid = false;
    private bool canClose = false;
    private bool closeTheLid = false;
    private bool isTrigger = false;
    private bool delayTime = false;
    private void Awake()
    {
        theLid = transform.Find("Lid Parent").gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        openLid();
        closeLid();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canClose && !openTheLid)
            {
                interactionCloseText.SetActive(true);
            }
            else if (!delayTime)
            {
                interactionText.SetActive(true);
                canOpen = true;
            }
            isTrigger = true;

            if (closeTheLid)
            {
                canClose = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interactionText.SetActive(false);
            interactionCloseText.SetActive(false);
            canClose = false;
            isTrigger = false;
        }
    }

    public void openLid()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                openTheLid = true;
                interactionText.SetActive(false);
            }

            if (openTheLid && theLid.transform.rotation.x > -180f / 360f)
            {
                theLid.transform.Rotate(-lidSpeed * Time.deltaTime, 0f, 0f);
            }
            else if (Mathf.Clamp(theLid.transform.rotation.x, -180f / 360f, 0f) == -180f / 360f)
            {
                canOpen = false;
                interactionText.SetActive(false);
                outsideTrigger.enabled = false;
                openTheLid = false;
            }
        }
    }

    public void closeLid()
    {
        if (canClose)
        {
            if (Input.GetKeyDown(KeyCode.E) && isTrigger)
            {
                closeTheLid = true;
                interactionCloseText.SetActive(false);
            }

            if (closeTheLid && theLid.transform.rotation.x <= 0)
            {
                theLid.transform.Rotate(lidSpeed * Time.deltaTime, 0f, 0f);
            }
            else if (Mathf.Clamp(theLid.transform.rotation.x, -180f / 360f, 0f) == 0f)
            {
                canClose = false;
                interactionCloseText.SetActive(false);
                delayTime = true;
                Destroy(rumba);
                outsideTrigger.enabled = false;
                transform.GetComponent<Oven>().enabled = false;
                transform.GetComponent<OvenMilk>().enabled = true;
            }
        }
    }

    public void setClose(bool close){
        canClose = close;
    }

    public void setRumba(GameObject rumbaInput)
    {
        rumba = rumbaInput;
    }

    public void setCollider(bool state)
    {
        outsideTrigger.enabled = state;
    }
}
