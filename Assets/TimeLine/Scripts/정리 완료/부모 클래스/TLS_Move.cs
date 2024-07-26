using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Move : MonoBehaviour
{
    Animator anim;
    [SerializeField] protected List<GameObject> movePos;
    [SerializeField] protected float speed;
    [SerializeField] protected float stopDistance = 0.8f;
    [SerializeField] protected int index = 0;
    [SerializeField] protected List<bool> isTrue;
    protected float distance;
    protected Coroutine moveCoroutine;
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        isTrue = new List<bool>(new bool[movePos.Count]);
    }

    protected virtual void MoveTowardsDestination()
    {
        Vector2 destination = movePos[index].transform.position;
        Vector2 newPos = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        distance = Vector3.Distance(transform.position, destination);
    }
}
