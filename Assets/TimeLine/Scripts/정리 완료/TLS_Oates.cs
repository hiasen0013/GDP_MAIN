using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TLS_Oates : MonoBehaviour
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

    public void Oates_Start_Anim()
    {
        if(TLS_Sequence_Manager.instance.is_First_TLS)
        {
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

    public void After_Jumping_Anim()
    {
        anim.SetTrigger("isAfterJumping");
    }
}
