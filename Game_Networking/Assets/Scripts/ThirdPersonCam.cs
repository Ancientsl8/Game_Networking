using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    //Camera Variables here
    Vector3 _look;
    [SerializeField] float rotateSpeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        //Get mouse movement
        _look.y = Input.GetAxis("Mouse X");

        transform.eulerAngles += new Vector3(0, _look.y * rotateSpeed * Time.deltaTime, 0);
    }
}
