using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float maxangle = 90f;

    private float rotationX = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.parent.Rotate(mouseX * sensitivity * Vector3.up);

        rotationX -= mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -maxangle, maxangle);
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
