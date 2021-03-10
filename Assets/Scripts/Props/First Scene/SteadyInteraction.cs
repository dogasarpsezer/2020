using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;
    [SerializeField]
    private Animator cameraAnimator;

    private bool interactedBefore = false;
    private bool steady = false;

    private float timer = 0;
    private void Awake()
    {
        cameraAnimator = transform.Find("Root").transform.Find("Main Camera").GetComponent<Animator>();
    }


    private void Update()
    {
        if (steady)
        {
            timer += Time.deltaTime * 1;
            if(timer >= 5f)
            {
                timer = 0f;
                Debug.Log("bruh");
                CancelSteady("isSteady");
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Bed"))
        {
            if (!interactedBefore)
            {
                textObject.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.E) && !interactedBefore)
            {
                textObject.SetActive(false);
                interactedBefore = true;
                steady = true;
                cameraAnimator.Play("CameraBedInteraction");
                cameraAnimator.SetBool("isSteady", true);
            }
        }

    }

    public void CancelSteady(string name)
    {
        steady = false;
        cameraAnimator.SetBool(name, steady);
    }

    public bool getSteady()
    {
        return steady;
    }
}
