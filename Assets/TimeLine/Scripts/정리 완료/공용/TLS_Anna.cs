using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Anna : TLS_AnimatorController
{
    protected override void Start()
    {
        base.Start();
    }

    public void Anna_Start_Anim()
    {
        SetAnimTrigger();
    }

    public void TLS_5_Anna_DownIdle()
    {
        anim.SetTrigger("TLS_5_DownIdle");
    }
}
