using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SystemManager : MonoBehaviour
{
    public GameObject stopUI;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            stopUI.SetActive(true);
        }
    }

    // Update is called once per frame
    public void StopMenu_StartClick()
    {
        Time.timeScale = 1;
        stopUI.SetActive(false);
    }
}
