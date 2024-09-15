using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_5_OatesMove : TLS_Move
{
    [SerializeField] private GameObject EndPos;
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

    public override void IsTrue()
    {
        base.IsTrue();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject == EndPos)
        {
            Destroy(this.gameObject);
        }
    }
}