using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Adeline : TLS_AnimatorController
{   
    [SerializeField] private int index;
    protected override void Start()
    {
        base.Start();
    }

    public void Edeline_Anim()
    {
        index++;
        switch(index)
        {
            case 1:
                anim.SetTrigger("Roar");
                break;
        }
    }
}
