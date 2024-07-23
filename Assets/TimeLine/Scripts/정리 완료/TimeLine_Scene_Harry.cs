using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine_Scene_Harry : MonoBehaviour
{
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if(anim == null)
            Debug.Log("애니미 널");
        else
            Debug.Log("애니미 있음");
    }

    public void Harry_Start_Anim()
    {
        if(TimeLine_Sequence_Manager.instance.is_First_CutScene)
        {
            Debug.Log("실행됨");
            anim.SetTrigger("isStart_First_CutScene");
        }
        if(TimeLine_Sequence_Manager.instance.is_Second_CutScene)
        {
            anim.SetTrigger("isSatrt_Second_CutScene");
        }
        if(TimeLine_Sequence_Manager.instance.is_Thrid_CutScene)
        {
            anim.SetTrigger("isStart_Thrid_CutScene");
        }
    }
    public void WakeUpAnim()
    {
        anim.SetTrigger("isWakeUp");
    }

    public void WakeUpMove()
    {
        anim.SetTrigger("isWakeUp2");
        this.gameObject.transform.localPosition = new Vector2 (2.732f, 0.04f);
    }
    public void WakeUP_Move3()
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
