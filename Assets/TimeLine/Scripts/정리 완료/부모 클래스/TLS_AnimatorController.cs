using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_AnimatorController : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected void SetAnimTrigger()
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
        if(TLS_Sequence_Manager.instance.is_Fifth_TLS)
        {
            anim.SetTrigger("isStart_Fifth_TLS");
        }
    }
}
