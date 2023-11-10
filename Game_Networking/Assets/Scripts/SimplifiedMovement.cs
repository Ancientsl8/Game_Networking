using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplifiedMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] Rigidbody rb;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    [Header("JumpStuff")]
    [SerializeField] private float jumpCD;
    [SerializeField] private Transform groundCheck;
    private float gravity = -20f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if ground is right below player
        grounded = Physics.Raycast(groundCheck.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);
    }
}
