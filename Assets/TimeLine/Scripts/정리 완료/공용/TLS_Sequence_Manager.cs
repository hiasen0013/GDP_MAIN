using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Sequence_Manager : MonoBehaviour
{
    public static TLS_Sequence_Manager instance;
    public bool is_First_TLS = false;
    public bool is_Second_TLS = false;
    public bool is_Thrid_TLS = false;
    public bool is_Fourth_TLS = false;
    public bool is_Fifth_TLS = false;


    public bool is_First_1_TLS = false;
    public int system_msg_count = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
    }

    public void First_TLS()
    {
        is_First_TLS = true;
        Debug.Log("1-1");
        system_msg_count = 0;
    }

    public void Second_TLS()
    {
        is_Second_TLS = true;
        Debug.Log("1-2");
        system_msg_count = 7;
    }

    public void Thrid_TLS()
    {
        is_Thrid_TLS = true;
        Debug.Log("1-3");
    }

    public void Fourth_TLS()
    {
        is_Fourth_TLS = true;
        Debug.Log("1-4");
    }

    public void Fifth_TLS()
    {
        is_Fifth_TLS = true;
        Debug.Log("1-5");
    }

    public void First_1_TLS()
    {
        is_First_1_TLS = true;
        Debug.Log("1-1번째");
    }
}
