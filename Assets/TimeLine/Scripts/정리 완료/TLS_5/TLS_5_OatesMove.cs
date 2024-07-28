using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_5_OatesMove : TLS_Move
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

    public void IsTrue()
    {
        isTrue[index] = true;
    }
}
