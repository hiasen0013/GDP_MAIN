using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TLS_Anna : MonoBehaviour
{
    Animator anim;
    public List<GameObject> movePos;
    public float speed = 2;
    public float stopDistance = 0.1f; // 목표 지점에 도달했다고 간주할 거리 기준
    int index = 0;
    bool isStartAnim = false;
    bool isGoBackAnim = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isStartAnim && index < movePos.Count)
            MoveTowardsDestination();
        
        if(isGoBackAnim && index < movePos.Count)
            MoveBackTowardsDestination();
        
    }

    void MoveTowardsDestination()
    {
        Vector3 destination = movePos[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance < stopDistance)
        {
            OnReachDestination();
        }
    }

    void MoveBackTowardsDestination()
    {
        if (index == 1) // movePosB의 위치를 변경하려는 인덱스를 명확히 함
        {
            movePos[1].transform.position = new Vector3(7.5f, -6.48f, 0);
        }

        Vector3 destination = movePos[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance < stopDistance)
        {
            OnReachDestination();
        }
    }
    void OnReachDestination()
    {
        if (isStartAnim && index < movePos.Count)
        {
            GameObject currentPos = movePos[index];
            if (currentPos.CompareTag("movePosA"))
            {
                anim.SetTrigger("isTurnRight");
                index++;
            }
            else if (currentPos.CompareTag("movePosB"))
            {
                anim.SetTrigger("isStop");
                isStartAnim = false;
                index = 0;
                TLS_Manager.instance.isDialog = false;
            }
        }
        else if (isGoBackAnim && index < movePos.Count)
        {
            GameObject currentPos = movePos[index];
            if (currentPos.CompareTag("movePosA"))
            {
                anim.SetTrigger("isTurnDown");
                index++;
            }
            else if (currentPos.CompareTag("movePosB"))
            {
                isGoBackAnim = false;
                index = 0;
                TLS_Manager.instance.isDialog = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    public void StartMove()
    {
        anim.SetTrigger("isStartAnim");
        isStartAnim = true;
        TLS_Manager.instance.isDialog = true;
    }

    public void BackMove()
    {
        speed = 4f;
        anim.SetTrigger("isGoBack");
        isGoBackAnim = true;
        TLS_Manager.instance.isDialog = true;
    }
}
