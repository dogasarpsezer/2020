using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseRotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform parentPlayer, childRoot;
    [SerializeField]
    private SteadyInteraction steadyInteraction;

    [SerializeField]
    private bool invertOption = false;

    [SerializeField]
    private float sensitivity = 5f;

    [SerializeField]
    private Vector2 xRotationLimits = new Vector2(-75f, 75f);

    [SerializeField]
    private bool canUnlock = true;


    private Vector2 lookAngle;
    private Vector2 currentMouseLook;
    private Vector2 smoothMove;

    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LookAround();
    }

    void Update()
    {
        CursorLockUnlock();

        if (Cursor.lockState == CursorLockMode.Locked)
        {
           LookAround();
        }

    }
    #region Methods
    public void CursorLockUnlock()
    {
        //Locking the mouse and unlocking it by pressing escape (for menu etc.)
        if (Input.GetKeyDown(KeyCode.Escape) && canUnlock)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void LookAround()
    {
        //Get the mouse axis
        currentMouseLook = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        //Define the lookAngle vector as the current mouse rotation and sensitivity multiplication
        lookAngle.x += currentMouseLook.x * sensitivity * (invertOption ? 1f : -1f);
        lookAngle.y += currentMouseLook.y * sensitivity;

        //Limit the rotation
        lookAngle.x = Mathf.Clamp(lookAngle.x, xRotationLimits.x, xRotationLimits.y);

        //Rotate the player
        childRoot.localRotation = Quaternion.Euler(lookAngle.x, 0f, 0f);
        parentPlayer.localRotation = Quaternion.Euler(0, lookAngle.y, 0f);
    }
    #endregion
}
