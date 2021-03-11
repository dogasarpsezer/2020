using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Collider doorCollider;
    [SerializeField]
    private GameObject[] elevatorDoors;
    [SerializeField]
    private float middlePoint1;
    [SerializeField]
    private float middlePoint2;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool canOpen = false;
    private bool once = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            closeDoors();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sa");
        canOpen = true;
        doorCollider.enabled = true;

    }

    public void closeDoors()
    {
        if (elevatorDoors[0].transform.localPosition.x >= middlePoint1 && elevatorDoors[1].transform.localPosition.x <= middlePoint2)
        {
            elevatorDoors[0].transform.localPosition = new Vector3(elevatorDoors[0].transform.localPosition.x - (speed * Time.deltaTime), elevatorDoors[0].transform.localPosition.y, elevatorDoors[0].transform.localPosition.z);
            elevatorDoors[1].transform.localPosition = new Vector3(elevatorDoors[1].transform.localPosition.x + (speed * Time.deltaTime), elevatorDoors[1].transform.localPosition.y , elevatorDoors[1].transform.localPosition.z);

        }
    }

}
