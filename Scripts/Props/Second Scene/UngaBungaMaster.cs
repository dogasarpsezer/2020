using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UngaBungaMaster : MonoBehaviour
{
    [SerializeField]
    private UngaBungaItemsMovement movement;

    private int counter = 0;
    private bool keyAppear = false;
    private void Awake()
    {
        movement = transform.GetComponent<UngaBungaItemsMovement>();

    }

    private void Update()
    {

        if (counter == 4)
        {
            keyAppear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("UngaBunga Item"))
        {
            if (other.gameObject.transform.parent != transform)
            {
                other.gameObject.transform.parent = transform;
                other.gameObject.transform.GetComponent<UngaBungaItemsMovement>().enabled = true;
                other.gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                if (other.gameObject.layer != 0)
                {
                    counter++;
                }
                other.gameObject.layer = 0;
                movement.setSpeed(movement.getSpeed() + 8f);

            }
        }
    }

    public bool getKey()
    {
        return keyAppear;
    }
}
