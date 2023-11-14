using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPlatformScript : MonoBehaviour
{
    private float timerStart;
    private float timerEnd;
    private bool isStepped = false;
    // Start is called before the first frame update
    void Start()
    {
        timerStart = 0;

        timerEnd = PlatformController.instance._endTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStepped)
        {
            timerStart += Time.deltaTime;
        }   

        if(timerStart > timerEnd)
        {
            timerStart = 0;
            gameObject.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isStepped = true;
        }
    }
}
