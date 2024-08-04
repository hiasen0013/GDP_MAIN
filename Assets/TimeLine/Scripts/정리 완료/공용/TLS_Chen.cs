using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Chen : TLS_AnimatorController
{
    [SerializeField] private int index;
    protected override void Start()
    {
        base.Start();
    }

    public void Chen_Start_Anim()
    {
        SetAnimTrigger();
    }

    public void Chen_TLS_5_Anim() // 0-5_지하3층_상담실
    {
        index ++;
        switch(index)
        {
            case 1:
                anim.SetTrigger("5_Down_Idle1");
                break;
            case 2:
                anim.SetTrigger("5_Down_Walk1");
                break;
            case 3:
                anim.SetTrigger("5_Down_Idle2");
                break;
            case 4:
                anim.SetTrigger("5_Right_Walk");
                break;
            case 5:
                anim.SetTrigger("5_Down_Walk2");
                break;
        }
    }
}
