using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float sprintSpeed = 10.0f; // Adjust the sprint speed
    public float acceleration = 5.0f; // Speed change rate
    private float currentSpeed;
    public float mouseSensitivity = 2.0f;
    public Transform playerCamera;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    public int maxJumps = 1;

    private CharacterController characterController;
    private float verticalVelocity;
    private float xRotation = 0f;
    private int jumpTimesLeft;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = speed;
        jumpTimesLeft = maxJumps;
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
        CheckLanding();
    }

    void MovePlayer()
    {
        float targetSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetSpeed = sprintSpeed;
        }

        // Smoothly interpolate towards the target speed
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * currentSpeed * Time.deltaTime);

        // Handle jumping input
        if (jumpTimesLeft > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jumpTimesLeft--;
        }

        // Apply gravity
        verticalVelocity += gravity * Time.deltaTime;
        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void CheckLanding()
    {
        // Check if the player has landed
        if (characterController.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
            jumpTimesLeft = maxJumps;
        }
    }
}
