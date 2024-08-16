using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Oate_Manager : MonoBehaviour
{
    public event System.Action oates_event;
    private Animator anim;
    private Vector3 targetPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool prolog0_0_Oates_Anim = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        //oates_event += MoveOates;

    }

    public void OatesEvent_Anim()
    {
        anim.SetTrigger("1_event_Anim_Start");
    }
}
