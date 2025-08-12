using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private PlayerControls controls;
    private Vector2 moveInput;
    private bool isJumpPressed;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Jump.performed += ctx => isJumpPressed = true;
    }

    private void OnEnable() => controls.Enable();
    private void OnDisable() => controls.Disable();

    private void FixedUpdate()
    {
        // movement
        Movement();

        // ground check
        CheckGround();

        // jump
        Jump();
    }

    // movement
    private void Movement()
    {
        Vector3 direction = new Vector3(moveInput.x, 0, moveInput.y);
        Vector3 move = transform.TransformDirection(direction) * moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    // ground check
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    // jump
    private void Jump()
    {
        if (isJumpPressed && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        isJumpPressed = false;
    }
}
