using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager instance;
    public bool is_First_CutScene = false;
    public bool is_Second_CutScene = false;
    public bool is_Thrid_CutScene = false;
    public int system_msg_count = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
    }

    public void First_CutScene()
    {
        is_First_CutScene = true;
        system_msg_count = 0;
    }

    public void Second_CutScene()
    {
        Debug.Log("두번째");
        is_Second_CutScene = true;
        system_msg_count = 7;
    }

    public void Thrid_CutScene()
    {
        is_Thrid_CutScene = true;
        Debug.Log(is_Thrid_CutScene);
    }
}
