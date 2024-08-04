using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Oates : TLS_AnimatorController
{
    [SerializeField] private int index;
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

    public void TLS5_Oates_Enter()
    {
        this.gameObject.transform.localPosition = new Vector2 (14.361f, 0.057f);
    }

    public void TLS_5_Oates_Anim()
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
                anim.SetTrigger("5_Right_Idle");
                break;
            case 5:
                this.gameObject.transform.localPosition = new Vector2(46.708f, 14.045f);
                anim.SetTrigger("5_Down_Idle");
                break;
            case 6:
                anim.SetTrigger("5_Right_Idle2");
                break;
            case 7:
                anim.SetTrigger("5_Down_Walk");
                break;
            case 8:
                this.gameObject.transform.localPosition = new Vector2(90.85f,-0.64f);
                anim.SetTrigger("5_Left_Walk2");
                break;
            case 9:
                anim.SetTrigger("5_Left_Idle");
                break;
            case 10:
                anim.SetTrigger("5_Up_Walk1");
                break;
            case 11:
                anim.SetTrigger("5_Up_Idle2");
                break;
        }
    }
}
