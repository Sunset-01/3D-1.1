using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Aplicar rotación en el eje Y al objeto controlador
        transform.Rotate(Vector3.up * mouseX);

        // Aplicar rotación en el eje X al cuerpo del jugador
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Movimiento
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        playerBody.position += move;
    }

    //void Update()
    //{
    //    // Movimiento del ratón
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    //    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

    //    // Aplicar rotación en el eje Y al cuerpo del jugador
    //    playerBody.Rotate(Vector3.up * mouseX);

    //    // Aplicar rotación en el eje X al objeto controlador
    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    //    transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    //    // Movimiento
    //    float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    //    float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

    //    Vector3 move = transform.right * moveX + transform.forward * moveZ;
    //    playerBody.position += move;
    //}
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FirstPersonController : MonoBehaviour
//{
//    public float speed = 5.0f;
//    public float mouseSensitivity = 2.0f;
//    public Transform playerBody;

//    float xRotation = 0f;

//    void Start()
//    {
//        Cursor.lockState = CursorLockMode.Locked;
//    }

//    void Update()
//    {
//        // Movimiento del ratón
//        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
//        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

//        xRotation -= mouseY;
//        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

//        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
//        playerBody.Rotate(Vector3.up * mouseX);

//        // Movimiento
//        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
//        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

//        Vector3 move = transform.right * moveX + transform.forward * moveZ;
//        playerBody.position += move;
//    }
//}
