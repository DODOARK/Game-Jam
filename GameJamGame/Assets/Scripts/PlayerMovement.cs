using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    public float movementSpeed = 1;
    public float jumpForce = 1;
    public float additionalGravity;

    private Vector3 movementVectors;

    private float mouseX;
    private float mouseY;

    public float mouseYClamp = 90;

    public Rigidbody rb;
    public Transform camTransform;

    private bool isGrounded;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1f);

        mouseX += Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        mouseX = Mathf.Repeat(mouseX, 359);
        mouseY = Mathf.Clamp(mouseY, -mouseYClamp, mouseYClamp);

        transform.localEulerAngles = new Vector3(0, mouseX, 0);
        camTransform.localEulerAngles = new Vector3(mouseY, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            movementVectors += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVectors -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVectors -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVectors += transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        movementVectors *= movementSpeed * 0.01f;
        rb.velocity = new Vector3(movementVectors.x, rb.velocity.y, movementVectors.z);
        if (!isGrounded)
        {
            rb.AddForce(-Vector3.up * additionalGravity, ForceMode.Acceleration);
        }
    }
}
