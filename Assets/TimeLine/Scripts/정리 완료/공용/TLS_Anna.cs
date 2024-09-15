using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Anna : TLS_AnimatorController
{
    [SerializeField] private int index;
    protected override void Start()
    {
        base.Start();
    }

    public void Anna_Start_Anim()
    {
        SetAnimTrigger();
    }

    public void TLS_5_Anna_Anim() // 0-5_지하3층_상담실
    {
        index ++;
        switch(index)
        {
            case 1:
                anim.SetTrigger("TLS_5_Down_Idle");
                break;
            case 2:
                anim.SetTrigger("TLS_5_Down_Walk1");
                break;
            case 3:
                anim.SetTrigger("TLS_5_Right_Walk");
                break;
            case 4:
                anim.SetTrigger("TLS_5_Anna_Down_Walk_2");
                break;
        }
    }
}
