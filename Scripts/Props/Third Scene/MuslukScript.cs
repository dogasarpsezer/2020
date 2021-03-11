using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuslukScript : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionText;

    private bool doneBefore = false;
    private bool availableForInput = false;
    private void Update()
    {
        if (availableForInput && Input.GetKeyDown(KeyCode.E) && !doneBefore)
        {
            doneBefore = true;
            interactionText.SetActive(false);
            //Func for musluk interaction
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (!doneBefore)
            {
                interactionText.SetActive(true);
                availableForInput = true;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactionText.SetActive(false);
        availableForInput = false;
    }
}
