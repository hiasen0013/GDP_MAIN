using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Oates_CutScene : MonoBehaviour
{
    public Animator anim;
    [SerializeField] Sprite jumpingImage;
    [SerializeField] SpriteRenderer spr;

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
        if(CutSceneManager.instance.is_First_CutScene)
        {
            anim.SetTrigger("isStart_First_CutScene");
        }
        if(CutSceneManager.instance.is_Second_CutScene)
        {
            anim.SetTrigger("isStart_Second_CutScene");
        }
        if(CutSceneManager.instance.is_Thrid_CutScene)
        {
            anim.SetTrigger("isStart_Thrid_CutScene");
        }
    }

    public void After_Jumping_Anim()
    {
        anim.SetTrigger("isAfterJumping");
    }
}
