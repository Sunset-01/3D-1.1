using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CharacterController))]
public class NewBehaviourScript : MonoBehaviour
{
    public Camera Playercamera;
    public float walkspeed = 6f;
    public float runspeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookspeed = 2f;
    public float lookXLimit = 45f;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;

    public bool canMove = true;

    CharacterController charactercontroller;
    void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runspeed : walkspeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runspeed : walkspeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && charactercontroller.isGrounded) 
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        if (!charactercontroller.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookspeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            Playercamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookspeed, 0);
        }
    }
}
