using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class TLS_KangGun : TLS_AnimatorController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public void KangGun_Start_Anim()
    {
        SetAnimTrigger();
    }

    public void TLS_4_After_jumping()
    {
        anim.SetTrigger("4_After_jumping");
    }
}
