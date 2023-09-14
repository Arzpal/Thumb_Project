using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]

    public float moveSpeed;

    public float groundDrag;

    public float jumpForce, jumpCooldown, airMultiplier;
    bool readyToJump = true;

    public Transform orientation;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    public bool isGrounded;


    float xInput, zInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        // freezing rotation because the PlayerCamera already does this
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        // ground check
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        InputController();
        VelocityController();

        // handles drag
        if (isGrounded)
        {
            rb.mass = 1;
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

	private void FixedUpdate()
	{
        MovePlayer();
	}

	private void InputController()
	{
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");

        // jump Input
        if (Input.GetButton("Jump") && readyToJump && isGrounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }

	}

    private void MovePlayer()
	{
        // calculate movement direction
        moveDirection = orientation.forward * zInput + orientation.right * xInput;

        if (isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!isGrounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
	}

    private void VelocityController()
	{
        Vector3 flatSpeed = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit speed if necessary
        if(flatSpeed.magnitude > moveSpeed)
		{
            Vector3 limitedSpeed = flatSpeed.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
		}
	}

    private void Jump()
	{
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

    private void ResetJump()
	{
        readyToJump = true;
	}

}
