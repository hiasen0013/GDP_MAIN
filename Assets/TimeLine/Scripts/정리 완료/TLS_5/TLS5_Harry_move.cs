using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS5_Harry_move : TLS_Move
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        /*if(isTrue[index])
        {
            TLS_Manager.instance.isDialog = true;
            MoveTowardsDestination();
            if(distance < stopDistance)
            {
                index ++;
                if(index < isTrue.Count)
                {
                    isTrue[index] = true;
                    isTrue[index-1] = false;
                }
                if (isTrue[1]) // 다음 목적지로 이동을 시작합니다.
                {
                    Debug.Log($"{isTrue.Count}");
                    Debug.Log($"{index}");
                    MoveTowardsDestination();
                    if(isTrue[1] && distance < stopDistance)
                    {
                        TLS_Manager.instance.isDialog = false;
                        isTrue[index] = false;
                        //index++;
                    }
                }
            }
        } */

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
    public void IsTrue()
    {
        isTrue[index] = true;
        Debug.Log($"{this.gameObject.name} isTrue{index} = {isTrue[index]}");
    }
}
 
