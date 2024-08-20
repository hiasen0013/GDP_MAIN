using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Oates_Manager : MonoBehaviour
{
    private Animator anim;
    public Transform targetPos;
    private NavMeshAgent agent;
    [SerializeField] private float moveSpeed;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(Oates_Event_1());
    }

    IEnumerator Oates_Event_1()
    {
        //anim.SetTrigger("1_event_Anim_1");
        //yield return new WaitForSeconds(2f);
        //anim.SetTrigger("1_evnet_Anim+_2");
        agent.speed = moveSpeed;
        agent.SetDestination(targetPos.position);
        yield break;
    }
}
