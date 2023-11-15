using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WindDirection
{
    North,
    East,
    West,
    South,
}
public class Fan_Direction : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody playerRGBD;
    [Header("Enum States")]
    [SerializeField] private WindDirection windDirection;
    [Header("Fan to Player Effects")]
    [SerializeField] private float windPower;
    [SerializeField] private float groundDrag; //We should use an inherited variable for groundDrag since it is also on PlayerController.cs, I commented the drag there for now.
    #endregion
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is in fan range");
            playerRGBD.drag = groundDrag;
            ApplyWindForce();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is not in fan range");
            playerRGBD.drag = 0;
        }
    }
    #region Methods
    private void ApplyWindForce()
    {
        Debug.Log("Fanning the Player");
        //Indicates which direction to push
        switch (windDirection)
        {
            case WindDirection.North:
                playerRGBD.AddForce(Vector3.forward * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindDirection.East:
                playerRGBD.AddForce(Vector3.right * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindDirection.West:
                playerRGBD.AddForce(Vector3.left * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindDirection.South:
                playerRGBD.AddForce(Vector3.back * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
        }
    }
    #endregion
}
