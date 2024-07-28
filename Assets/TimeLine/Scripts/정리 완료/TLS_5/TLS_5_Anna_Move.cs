using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_5_Anna_Move : TLS_Move
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
                isTrue[index - 1] = false;
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

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(distance < stopDistance && other.gameObject.name == "Anna_MovePos_3")
        {
            Debug.Log("ㅇㅇ");
            Destroy(this.gameObject);
        }
    }

    public void IsTrue()
    {
        isTrue[index] = true;
    }
}
