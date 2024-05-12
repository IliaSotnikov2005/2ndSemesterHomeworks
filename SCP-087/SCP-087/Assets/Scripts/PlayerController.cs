using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    public float gravity = 9.81f;
    private float fallSpeed = 0f;
    public float jumpSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;


        if (controller.isGrounded)
        {
            fallSpeed = 0f;
        }
        else
        {
            fallSpeed -= gravity * Time.deltaTime;
            moveDirection.y = fallSpeed;
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            fallSpeed = jumpSpeed;
        }

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
