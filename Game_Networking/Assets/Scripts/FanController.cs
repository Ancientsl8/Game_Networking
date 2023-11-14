using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public static FanController instance;

    public GameObject _player;

    private void Awake()
    {
        instance = this;
    }

    public Rigidbody GetPRigidBody()
    {
        return _player.GetComponent<Rigidbody>();
    }
}
