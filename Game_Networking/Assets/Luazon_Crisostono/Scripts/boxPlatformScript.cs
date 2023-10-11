using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPlatformScript : MonoBehaviour
{
    public float timerStart;
    public float timerEnd;
    private bool isStepped = false;
    // Start is called before the first frame update
    void Start()
    {
        timerStart = 0;
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

        Debug.Log(timerStart);

    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isStepped = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isStepped = false;
            timerStart = 0;
        }
    }
}
