using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdKey : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float forceSpeed;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.AddForce(transform.up * forceSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
