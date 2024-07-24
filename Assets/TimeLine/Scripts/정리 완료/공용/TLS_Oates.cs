using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TLS_Oates : TLS_AnimatorController
{
    protected override void Start()
    {
        base.Start();
    }

    public void Oates_Start_Anim()
    {
        SetAnimTrigger();
    }

    public void After_Jumping_Anim()
    {
        anim.SetTrigger("isAfterJumping");
    }

    public void TLS5_Oates_appear()
    {
        this.gameObject.transform.localPosition = new Vector2 (14.361f, 0.057f);
    }

    public void TLS5_Oates_BackMove()
    {
        anim.SetTrigger("TLS_5_Oates_BakcMove");
    }
}
