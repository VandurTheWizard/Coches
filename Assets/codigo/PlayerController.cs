using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("General")]
    public float gravityScale = -20f;
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float planeSpeed = 20f;
    public float apacheSpeed = 15f;
    public float carSpeed = 12f;
    [Header("Camera")]
    public float rotationSensibility = 30f;
    [Header("Jump")]
    public float jumpHeight = 1.9f;
    [Header("References")]
    public Transform objectToRotate; // Para las camaras y armas

    [Header("References")]
    public PauseManager pauseManager;

    private float cameraVerticalAngle;
    private Vector3 moveInput = Vector3.zero;
    private Vector3 rotationInput = Vector3.zero;
    private CharacterController characterController;
    private Vector2 move;
    private Vector2 look;
    private bool isSprinting;
    private bool isJumping;
    private bool isPaused = false;

    public bool isPlane = false;
    public bool isApache = false;
    public bool isCar = false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //CursorHide();
    }

    private void Update()
    {
        Look();
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        isJumping = context.ReadValueAsButton();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Move()
    {
        if (isPaused) return;

        if (isPlane)
        {
            // Movimiento de avión
            moveInput = new Vector3(move.x, isJumping ? 1 : -1, move.y);
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput = transform.TransformDirection(moveInput) * planeSpeed;
        }
        else if (isApache)
        {
            // Movimiento de helicóptero
            moveInput = new Vector3(move.x, isJumping ? 1 : 0, move.y);
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput = transform.TransformDirection(moveInput) * apacheSpeed;
        }
        else if (isCar)
        {
            // Movimiento de coche
            moveInput = new Vector3(move.x, 0, move.y);
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            moveInput = transform.TransformDirection(moveInput) * carSpeed;
        }
        else
        {
            // Movimiento a pie (original)
            if (characterController.isGrounded)
            {
                moveInput = new Vector3(move.x, 0, move.y);
                moveInput = Vector3.ClampMagnitude(moveInput, 1f);

                if (isSprinting)
                {
                    moveInput = transform.TransformDirection(moveInput) * runSpeed;
                }
                else
                {
                    moveInput = transform.TransformDirection(moveInput) * walkSpeed;
                }

                if (isJumping)
                {
                    moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
                }
            }

            moveInput.y += gravityScale * Time.deltaTime;
        }

        characterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotationInput = new Vector3(-look.y, look.x, 0) * rotationSensibility * Time.deltaTime;
        cameraVerticalAngle += rotationInput.x;
        cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -90f, 90f);

        objectToRotate.localEulerAngles = new Vector3(cameraVerticalAngle, 0, 0);
        transform.Rotate(Vector3.up * rotationInput.y);
    }

    public void Pause()
    {
        isPaused = true;
        Debug.Log("Pause");
        CursorShow();
        pauseManager.ChangeActiveState(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isPaused = false;
        Debug.Log("Resume");
        CursorHide();
        pauseManager.ChangeActiveState(false);
        Time.timeScale = 1;
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public void CursorShow()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CursorHide()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
