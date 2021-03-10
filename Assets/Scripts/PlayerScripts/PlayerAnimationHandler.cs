using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField]
    private Animator playerCameraAnimationController;
    [SerializeField]
    private CharacterController playerController;
    private void Awake()
    {
        playerCameraAnimationController = transform.Find("Root").transform.Find("Main Camera").GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //If there is velocity more than 1 activate the walking anmation
        if(playerController.velocity.sqrMagnitude > 1f)
        {
            playerCameraAnimationController.SetBool("isWalking", true);
        }
        else
        {
            playerCameraAnimationController.SetBool("isWalking", false);
        }
    }
}
