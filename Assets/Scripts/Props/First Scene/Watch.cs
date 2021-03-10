using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    [SerializeField]
    private GameObject keyobject;

    private void Awake()
    {
        keyobject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Debug.Log("DING!!!!");
            keyobject.SetActive(true);
        }
    }
}
