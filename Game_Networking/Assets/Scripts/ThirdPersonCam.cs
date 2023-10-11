using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;

    [SerializeField] float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, player.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
