// <copyright file="CameraController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;

/// <summary>
/// COntroller for the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 2f;
    [SerializeField]
    private float maxangle = 90f;

    private float rotationX = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        this.transform.parent.Rotate(mouseX * this.sensitivity * Vector3.up);

        this.rotationX -= mouseY * this.sensitivity;
        this.rotationX = Mathf.Clamp(this.rotationX, -this.maxangle, this.maxangle);
        this.transform.localRotation = Quaternion.Euler(this.rotationX, 0f, 0f);
    }
}
