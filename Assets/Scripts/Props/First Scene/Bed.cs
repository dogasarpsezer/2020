using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject playerBedCamera;
    [SerializeField]
    private GameObject interactionText;
    [SerializeField]
    private AnimationClip rumbaComingAnim;
    [SerializeField]
    private GameObject trapRumba;
    [SerializeField]
    private Collider triggerCollider;

    [SerializeField]
    private float backoffTimer = 3;
    [SerializeField]
    private float rumbaComingDelayer = 3;

    float timer = 0;
    private bool isOnceDone = false;
    private void Awake()
    {
        player = GameObject.Find("Player");
        playerBedCamera = transform.Find("Player Bed Camera").gameObject;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOnceDone)
        {
            timer += Time.deltaTime * 1; 
            if (timer >= backoffTimer && timer < backoffTimer + rumbaComingAnim.length)
            {
                BackoffAnim();
            }
            else if (timer >= backoffTimer + rumbaComingAnim.length)
            {
                BackToPlayer();
            }

        }



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isOnceDone)
        {
            interactionText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionText.SetActive(false);
                player.SetActive(false);
                playerBedCamera.SetActive(true);
                isOnceDone = true;
            }
        }

    }

    public void BackoffAnim()
    {
        triggerCollider.enabled = false;
        trapRumba.transform.GetComponent<RumbaMovement>().WakeUp();
        playerBedCamera.transform.GetComponent<Animator>().SetTrigger("isComing");
    }

    public void BackToPlayer()
    {
        player.SetActive(true);
        playerBedCamera.SetActive(false);
    }
}
