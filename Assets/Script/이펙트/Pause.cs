using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool IsPause;

    void Start()
    {
        IsPause = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;

                return;
            }

            if(IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;

                return;
            }
        }
    }
}
