using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenMilk : MonoBehaviour
{
    [SerializeField]
    private float timeInTheOven;
    [SerializeField]
    private GameObject ovenLid;
    [SerializeField]
    private float lidSpeed;
    [SerializeField]
    private GameObject milk;

    private bool canOpen = false;
    void Start()
    {
        Invoke("OpenToTrue", timeInTheOven);
    }

    // Update is called once per frame
    void Update()
    {
        openTheLid();
    }

    public void OpenToTrue()
    {
        canOpen = true;
        milk.SetActive(true);
    }

    public void openTheLid()
    {
        if (canOpen)
        {
            if (ovenLid.transform.rotation.x > -180f / 360f)
            {
                ovenLid.transform.Rotate(-lidSpeed * Time.deltaTime, 0f, 0f);
            }
            else if (Mathf.Clamp(ovenLid.transform.rotation.x, -180f / 360f, 0f) == -180f / 360f)
            {
                canOpen = false;
                
            }
        }
    }
}
