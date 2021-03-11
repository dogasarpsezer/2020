using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rumba : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private RumbaMovement rumbaMove;
    [SerializeField]
    private float delayTime;

    private bool onGround = false;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
        rumbaMove = transform.GetComponent<RumbaMovement>();
    }
    void Start()
    {
        Invoke("Delayer", delayTime);
    }

    public void Delayer()
    {
        gameObject.layer = 8;
        rb.constraints = RigidbodyConstraints.None;
        rumbaMove.setSpeed(5);
    }
}
