using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UngaBungaItemsMovement : MonoBehaviour
{
    [SerializeField]
    private UngaBungaItemsMovement parentScript;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool isParent;
    void Update()
    {
        transform.Rotate( new Vector3(0f,-(speed *Time.deltaTime),0f) ,Space.Self);
        if(!isParent)
            speed = parentScript.getSpeed() / 4;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}
