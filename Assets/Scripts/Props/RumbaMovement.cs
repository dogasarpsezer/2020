using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbaMovement : MonoBehaviour
{
    [SerializeField]
    private float rumbaSpeed;
    [SerializeField]
    private bool isAwake = true;
    private void Update()
    {
        if (!isAwake)
        {
            return;
        }

        transform.Translate(Vector3.forward * rumbaSpeed * Time.deltaTime, Space.Self);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Ground") && !other.gameObject.CompareTag("Fridge"))
        {
            gameObject.transform.Rotate(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y + 120f, gameObject.transform.localRotation.z);  
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

    }
    public void WakeUp()
    {
        isAwake = true;
    }

    public void setSpeed(float speed)
    {
        rumbaSpeed = speed;
    }

}
