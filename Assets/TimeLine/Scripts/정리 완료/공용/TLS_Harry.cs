using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Harry : TLS_AnimatorController
{
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
}
    
