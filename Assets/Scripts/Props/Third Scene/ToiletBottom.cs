using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletBottom : MonoBehaviour
{
    private int counter = 0;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toilet Interaction"))
        {
            counter++;
            other.gameObject.layer = 0;
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Toilet Interaction"))
        {
            other.gameObject.layer = 0;
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    public int getCounter()
    {
        return counter;
    }
}
