using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKeyScript : MonoBehaviour
{
    [SerializeField]
    private float keyAscendSpeed;
    [SerializeField]
    private float effectSpeed;
    [SerializeField]
    private float keyAscendLimit;
    [SerializeField]
    private float keyDescendLimit;

    private bool topReached = false;

    private void Update()
    {

        if (!topReached)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,(gameObject.transform.position.y + (keyAscendSpeed * Time.deltaTime)), gameObject.transform.position.z);
            if (gameObject.transform.position.y >= keyAscendLimit)
            {
                topReached = true;
                gameObject.layer = 8;
                keyAscendSpeed = effectSpeed;
            }
        }
        else{
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y - (keyAscendSpeed * Time.deltaTime)), gameObject.transform.position.z);
            if (gameObject.transform.position.y <= keyDescendLimit)
            {
                topReached = false;
            }
        }

        
    }
}
