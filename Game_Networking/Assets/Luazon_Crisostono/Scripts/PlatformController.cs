using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public static PlatformController instance;

    public float _endTimer;

    private void Awake()
    {
        instance = this;
    }
}
