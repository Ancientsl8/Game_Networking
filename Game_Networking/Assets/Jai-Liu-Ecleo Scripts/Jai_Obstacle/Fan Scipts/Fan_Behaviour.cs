using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum FanState
{
    On,
    Off
}
public enum WindState
{
    North,
    East,
    West,
    South
}
public class Fan_Behaviour : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private BoxCollider triggerCollider;
    [Header("Enum States")]
    [SerializeField] private FanState fanState;
    [SerializeField] private WindState windState;
    private int randomFanStateChangeTiming;
    private Rigidbody playerRGBD;
    [Header("Fan to Player Effects")]
    [SerializeField] private float windPower;
    [SerializeField] private float groundDrag; //We should use an inherited variable for groundDrag since it is also on PlayerController.cs, I commented the drag there for now.
    #endregion

    private void Awake()
    {
        playerRGBD = FanController.instance.GetPRigidBody();
    }

    private void Start()
    {
        RandomFanStateSwitchTiming();
        Debug.Log(randomFanStateChangeTiming);
        StartCoroutine(FanStateCoroutine(randomFanStateChangeTiming));
    }
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
    private void RandomFanStateSwitchTiming()
    {
        //To randomize the timing of fan state switch
        randomFanStateChangeTiming = Random.Range(1, 3);
    }
    private void FanCoroutineHandler()
    {
        //Fan is on
        if (triggerCollider.enabled == true)
        {
            Debug.Log("Fan is On");
            RandomFanStateSwitchTiming();
            Debug.Log(randomFanStateChangeTiming);
            StartCoroutine(FanStateCoroutine(randomFanStateChangeTiming));
        }
        //Fan is off
        else if (triggerCollider.enabled == false)
        {
            Debug.Log("Fan is Off");
            RandomFanStateSwitchTiming();
            Debug.Log(randomFanStateChangeTiming);
            StartCoroutine(FanStateCoroutine(randomFanStateChangeTiming));
        }
    }
    private IEnumerator FanStateCoroutine(float countdown)
    {
        yield return new WaitForSeconds(countdown);
        //Swith Fan State from on to off and vice versa
        switch (fanState)
        {
            case FanState.On:
                //triggerCollider.enabled = false;
                fanState = FanState.Off;
                break;
            case FanState.Off:
                //triggerCollider.enabled = true;
                fanState = FanState.On;
                break;
        }
        FanCoroutineHandler();
    }
    private void ApplyWindForce()
    {
        Debug.Log("Fanning the Player");
        //Indicates which direction to push
        switch (windState)
        {
            case WindState.North:
                playerRGBD.AddForce(Vector3.forward * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindState.East:
                playerRGBD.AddForce(Vector3.right * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindState.West:
                playerRGBD.AddForce(Vector3.left * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
            case WindState.South:
                playerRGBD.AddForce(Vector3.back * windPower * Time.deltaTime, ForceMode.VelocityChange);
                break;
        }
    }
    #endregion
}
