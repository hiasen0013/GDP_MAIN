using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TLS_5_Chen : TLS_Move
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if(index < isTrue.Count && isTrue[index])
        {
            TLS_Manager.instance.isDialog = true;
            MoveTowardsDestination();
            if(distance < stopDistance)
            {
                TLS_Manager.instance.isDialog = false;
                index ++;
                isTrue[index-1] = false;
            }
        }

        if(index >= isTrue.Count)
        {   
            return;
        }
    }
    protected override void MoveTowardsDestination()
    {
        base.MoveTowardsDestination();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Chen_MovePos_3")
        {
            Destroy(this.gameObject);
        }
    }
    public void IsTrue()
    {
        isTrue[index] = true;
        Debug.Log($"{this.gameObject.name} isTrue{index} = {isTrue[index]}");
    }
}

    /*
    private IEnumerator MoveCoroutine()
    {
        if(isTrue[index])
        {
            while(true)
            {
                if(isTrue[index])
                {
                    MoveTowardsDestination();
                    TLS_Manager.instance.isDialog = true;
                    if(distance < stopDistance)
                    {
                        if(index <= isTrue.Count)
                        {
                            isTrue[index] = false;
                            index ++;
                            TLS_Manager.instance.isDialog = false;
                            Debug.Log($"{this.gameObject.name}이 movePos{movePos[index]}에 도착함");
                            yield return new WaitUntil(() => index < isTrue.Count && isTrue[index]);
                        }
                    }
                    Debug.Log($"{this.gameObject.name}이 movePos{movePos[index]}로  이동중");
                    yield return null;
                }
            }
        }
    }


    public void IsTrue()
    {
        isTrue[index] = true;
        Debug.Log($"{this.gameObject.name}의 isTrue{index} = {isTrue[index]}");
        CoroutineStart_and_Restart();
    }
    private void CoroutineStart_and_Restart()
    {
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            Debug.Log("코루틴 멈춤");
        }
        moveCoroutine = StartCoroutine(MoveCoroutine());
    }
    */