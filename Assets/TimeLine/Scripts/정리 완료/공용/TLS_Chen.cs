using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void Chen_TLS_1_1_Anim() // 1-1_프롤로그_1
    {
        index ++;
        switch(index)
        {
            case 1:
                anim.SetTrigger("1_1_Right_Walk");
                break;
            case 2:
                anim.SetTrigger("1_1_Right_Idle");
                break;
            case 3:
                anim.SetTrigger("1_1_Left_Walk");
                break;
            case 4:
                anim.SetTrigger("1_1_Down_Walk");
                break;
        }
    }

    public void Chen_TLS_1_2_Anim() // 1-2 로비 / 엘베안/ 실험실 컷씬
    {
        index++;
        switch(index)
        {
            case 1:
                this.gameObject.transform.localPosition = new Vector3(107.55f, -7.04f, 0);
                anim.SetTrigger("1_2_Down_Idle1");
                break;
            case 2:
                anim.SetTrigger("1_2_Left_Walk");
                break;
            case 3:
                anim.SetTrigger("1_2_Down_Walk");
                break;
            case 4:
                anim.SetTrigger("1_2_Down_Idle2");
                break;
        }
    }
}