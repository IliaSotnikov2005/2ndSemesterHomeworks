using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    public float gravity = 9.81f;
    private float fallSpeed = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        if (controller.isGrounded)
        {
            fallSpeed = -2f;
        }
        else
        {
            fallSpeed -= gravity * Time.deltaTime;
            moveDirection.y = fallSpeed;
        }

        controller.Move(moveSpeed * Time.deltaTime * moveDirection);
    }
}
