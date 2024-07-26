using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TLS_5_Chen : TLS_Move
{
    protected override void Start()
    {
        base.Start();

        isTrue[index] = true;
        Debug.Log($"챈의 isTrue{index} = {isTrue[index]}");

        CoroutineStart_and_Restart();
    }

    protected override void MoveTowardsDestination()
    {
        base.MoveTowardsDestination();
    }

    private void CoroutineStart_and_Restart()
    {
        moveCoroutine = StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        if(isTrue[index])
        {
            while(true)
            {
                if(isTrue[index])
                {
                    MoveTowardsDestination();
                    if(distance < stopDistance)
                    {
                        if(index <= isTrue.Count)
                        {
                            isTrue[index] = false;
                            index ++;
                            Debug.Log(index);
                            yield return new WaitUntil(() => index < isTrue.Count && isTrue[index]);
                        }
                    }
                    Debug.Log("이동중");
                    yield return null;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.name == "Chen_MovePos_3")
        {
            Destroy(this.gameObject);
        }
    }
}
