using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private float playerSpeed;
    private Vector3 moveDirection;
    [SerializeField]
    private float gravity = 9.8f;
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //Take the ınput axis and make them intro a direction vector. Multiply it by speed and use move function to move the object with the speed gicen in the direction.
        moveDirection = new Vector3(Input.GetAxis(horizontal), 0f, Input.GetAxis(vertical));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= playerSpeed * Time.deltaTime;
        AddGravity();
        playerController.Move(moveDirection);
        //Debug.Log(moveDirection);
    }

    public void AddGravity()
    {
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
