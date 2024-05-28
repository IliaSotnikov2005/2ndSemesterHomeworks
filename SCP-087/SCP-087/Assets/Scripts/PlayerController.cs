// <copyright file="PlayerController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// Controller for player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float gravity = 9.81f;

    private CharacterController controller;
    private float fallSpeed = 0f;

    private void Start()
    {
        this.controller = this.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (this.transform.forward * verticalInput) + (this.transform.right * horizontalInput);

        if (this.controller.isGrounded)
        {
            this.fallSpeed = -2f;
        }
        else
        {
            this.fallSpeed -= this.gravity * Time.deltaTime;
            moveDirection.y = this.fallSpeed;
        }

        this.controller.Move(this.moveSpeed * Time.deltaTime * moveDirection);
    }
}
