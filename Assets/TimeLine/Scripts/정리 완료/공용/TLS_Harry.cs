using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Harry : TLS_AnimatorController
{
    [SerializeField] private int index;
    protected override void Start()
    {
        base.Start();
    }

    public void Harry_Anim_Start()
    {
        SetAnimTrigger();
    }
    public void WakeUp_Anim()
    {
        anim.SetTrigger("isWakeUp");
    }
    public void WakeUp_Move()
    {
        anim.SetTrigger("isWakeUp2");
        this.gameObject.transform.localPosition = new Vector2 (2.732f, 0.04f);
    }
    public void WakeUP_Move2()
    {
        anim.SetTrigger("isWakeUp3");
        this.gameObject.transform.localPosition = new Vector2 (1.82f, 0.04f);
    }

    public void Scene2_WalkForward()
    {
        anim.SetTrigger("Scene2_isWalk");
    }
    
    public void Scene2_WalkEnd()
    {
        anim.SetTrigger("Scene2_isWalk_end");
    }

    public void TLS5_Harry_Enter()
    {
        this.gameObject.transform.localPosition = new Vector2 (15.353f, 0.115f);
    }

    public void TLS_5_Harry_Anim()
    {
        index ++;
        switch(index)
        {
            case 1:
                anim.SetTrigger("5_Up_Walk");
                break;
            case 2:
                anim.SetTrigger("5_Left_Walk");
                break;
            case 3:
                anim.SetTrigger("5_Up_Idle");
                break;
            case 4:
                anim.SetTrigger("5_Left_Idle");
                break;
            case 5:
                this.gameObject.transform.localPosition = new Vector2(47.7f, 14.11f);
                anim.SetTrigger("5_Down_Idle");
                break;
            case 6:
                anim.SetTrigger("5_Left_Idle2");
                break;
            case 7:
                anim.SetTrigger("5_Donw_Walk");
                break;
            case 8:
                this.gameObject.transform.localPosition = new Vector2(89.89f,-0.5750006f);
                anim.SetTrigger("5_Left_Walk2");
                break;
            case 9:
                anim.SetTrigger("5_Right_Idle");
                break;
        }
    }
}
    
