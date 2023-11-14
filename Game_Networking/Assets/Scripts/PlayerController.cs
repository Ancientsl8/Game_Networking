using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    [Header("Jump Stuff")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCD;
    [SerializeField] private float airMultiplier;
    bool readyToJump;
    [SerializeField] private Transform groundCheck;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        readyToJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        // checks using a laser to determine if player is on the ground.
        grounded = Physics.Raycast(groundCheck.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        InputAxi();
        SpeedControl();
        // Checks if player is grounded to drag
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        // When to jump
        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCD);
        }

       
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    //Gets inputs from player to determine direction
    private void InputAxi()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    // Checks player direction + moves player in that direction
    private void MovePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
        }

         else if (!grounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }
    // Limits speed to keep it consistent (can't be my work schedule)
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    //resets jump check after jump
    private void ResetJump()
    {
        readyToJump = true;
    }
}
