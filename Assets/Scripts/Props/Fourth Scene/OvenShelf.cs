using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenShelf : MonoBehaviour
{
    [SerializeField]
    private Oven oven;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Rumba"))
        {
           other.gameObject.layer = 0;
           oven.setClose(true);
           oven.setRumba(other.gameObject);
           oven.setCollider(true);
        }
    }
}
