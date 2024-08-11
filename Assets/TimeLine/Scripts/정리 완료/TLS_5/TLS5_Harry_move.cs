using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS5_Harry_move : TLS_Move
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }    protected override void MoveTowardsDestination()
    {
        base.MoveTowardsDestination();
    }
    public override void IsTrue()
    {
        base.IsTrue();
    }

    public void TLS_2_1()
    {
        IsTrue();
        TLS_Manager.instance.isDialog = false;
    }
}
 

        /*
        if(isTrue[index])
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
        } 
        */