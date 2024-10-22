using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Move : MonoBehaviour
{
    Animator anim;
    [SerializeField] protected List<GameObject> movePos;
    [SerializeField] protected float speed;
    [SerializeField] protected float stopDistance = 0.01f;
    [SerializeField] protected int index = 0;
    [SerializeField] protected List<bool> isTrue;
    protected float distance;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        isTrue = new List<bool>(new bool[movePos.Count]);
    }

    protected virtual void Update()
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

    protected virtual void MoveTowardsDestination()
    {
        Vector2 destination = movePos[index].transform.position;
        Vector2 newPos = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        distance = Vector2.Distance(transform.position, destination);
        Debug.Log($"{this.gameObject.name}가 movePos{movePos[index]}로  이동중");
    }

    public virtual void IsTrue()
    {
        isTrue[index] = true;
        Debug.Log($"{this.gameObject.name} isTrue{index} = {isTrue[index]}");
    }
}