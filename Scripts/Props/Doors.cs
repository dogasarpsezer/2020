using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AxisToRotate{
    Yaxis,
    Xaxis,
    Zaxis
}

public class Doors : MonoBehaviour
{
    [SerializeField]
    private GameObject doorInteratablePart;
    [SerializeField]
    private Collider doorCollider;
    private bool isDoorOpening = false;
    private bool isDoorClosing = false;
    [SerializeField]
    private AxisToRotate axis;

    [SerializeField]
    private float limitOpenDegreeZ;
    [SerializeField]
    private float doorOpeningSpeed;
    [SerializeField]
    private float doorClosingSpeed;

    private float currentDegreeZ = 0;
    private void Awake()
    {
        //doorInteratablePart = transform.Find("Door").transform.Find("Door").gameObject;
        doorCollider = transform.GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        openTheDoor();
        closeTheDoor();

        if (isDoorClosing)
        {
            doorCollider.isTrigger = false;
        }

        if (isDoorOpening)
        {
            doorCollider.isTrigger = true;
        }
    }

    public void openTheDoor()
    {
        if(axis == AxisToRotate.Zaxis)
        {
            if (isDoorOpening && currentDegreeZ < limitOpenDegreeZ / 180 && !isDoorClosing)
            {
                currentDegreeZ = doorInteratablePart.transform.localRotation.z;
                Debug.Log(currentDegreeZ);
                doorInteratablePart.transform.Rotate(0f, 0f, currentDegreeZ + (doorOpeningSpeed * Time.deltaTime));
            }
            else
            {
                isDoorOpening = false;
            }
        }
        else if(axis == AxisToRotate.Yaxis)
        {
            if (isDoorOpening && currentDegreeZ < limitOpenDegreeZ / 180 && !isDoorClosing)
            {
                currentDegreeZ = doorInteratablePart.transform.localRotation.y;
                Debug.Log(currentDegreeZ);
                doorInteratablePart.transform.Rotate(0f, currentDegreeZ + (doorOpeningSpeed * Time.deltaTime),0f);
            }
            else
            {
                isDoorOpening = false;
            }
        }

    }

    public void closeTheDoor()
    {
        if (axis == AxisToRotate.Zaxis)
        {
            if (isDoorClosing && currentDegreeZ > 0 && !isDoorOpening)
            {
                currentDegreeZ = doorInteratablePart.transform.localRotation.z;
                doorInteratablePart.transform.Rotate(0f, 0f, -(currentDegreeZ + (doorClosingSpeed * Time.deltaTime)));
            }
            else
            {
                isDoorClosing = false;
            }
        }
        else if(axis == AxisToRotate.Yaxis)
        {
            if (isDoorClosing && currentDegreeZ > 0 && !isDoorOpening)
            {
                currentDegreeZ = doorInteratablePart.transform.localRotation.y;
                doorInteratablePart.transform.Rotate(0f,-(currentDegreeZ + (doorClosingSpeed * Time.deltaTime)),0f);
            }
            else
            {
                isDoorClosing = false;
            }
        }

    }

    public void setOpen(bool isOpen)
    {
        isDoorOpening = isOpen;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Sa");
            doorCollider.isTrigger = false;
            isDoorClosing = true;
        }
    }
}
