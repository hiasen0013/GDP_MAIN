using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_5_Anna_Move : TLS_Move
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void MoveTowardsDestination()
    {
        base.MoveTowardsDestination();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(distance < stopDistance && other.gameObject.name == "Anna_MovePos_3")
        {
            Destroy(this.gameObject);
        }
    }

    public override void IsTrue()
    {
        base.IsTrue();
    }
}