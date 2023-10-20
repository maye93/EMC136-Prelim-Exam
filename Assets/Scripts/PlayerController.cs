using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 5f;

    private Camera playerCamera;
    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();

        // Freeze rotation to prevent falling over
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleMovementInput();
        HandleMouseLook();
    }

    void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;

        transform.Translate(moveVelocity * Time.deltaTime, Space.Self);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera up and down (limited to avoid flipping)
        float newRotationX = Mathf.Clamp(playerCamera.transform.localEulerAngles.x - mouseY, 0f, 90f);
        playerCamera.transform.localEulerAngles = new Vector3(newRotationX, 0f, 0f);
    }
}
