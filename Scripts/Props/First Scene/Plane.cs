using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField]
    private Rigidbody planeRigid;
    private void Awake()
    {
        planeRigid = gameObject.transform.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            planeRigid.useGravity = true;
        }
    }
}
