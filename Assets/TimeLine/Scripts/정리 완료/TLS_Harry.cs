using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Harry : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
            Debug.Log("애니미 널");
        else
            Debug.Log("애니미 있음");
    }

    public void Harry_Anim_Start()
    {
        if(TLS_Sequence_Manager.instance.is_First_TLS)
        {
            Debug.Log("실행됨");
            anim.SetTrigger("isStart_First_TLS");
        }
        if(TLS_Sequence_Manager.instance.is_Second_TLS)
        {
            anim.SetTrigger("isStart_Second_TLS");
        }
        if(TLS_Sequence_Manager.instance.is_Thrid_TLS)
        {
            anim.SetTrigger("isStart_Thrid_TLS");
        }
        if(TLS_Sequence_Manager.instance.is_Fourth_TLS)
        {
            anim.SetTrigger("isStart_Fourth_TLS");
        }
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
}
    
