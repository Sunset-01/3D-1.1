using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalMove;
    public float verticalMove;
    public CharacterController characterController;
    public float playerSpeed;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove = 1;
        }
        else if (Input.GetKey(KeyCode.S)) 
        { 
            verticalMove = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalMove = -1;
        }
        else if (Input.GetKey(KeyCode.W)) 
        { 
            verticalMove = 1; 
        }
        else
        {
            horizontalMove = 0;
            verticalMove = 0;
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(new Vector3(horizontalMove, 0,verticalMove) * playerSpeed * Time.deltaTime);
    }
}
