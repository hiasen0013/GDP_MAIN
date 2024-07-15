using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed;
    public float walkCount;
    protected int currentWalkCount;

    protected Vector3 vector;

    public BoxCollider2D boxCollider;
    public LayerMask layerMask;
    public Animator anim;

    float h;
    float v;

    public GameManager manager;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected void Move(string _dir)
    {
        StartCoroutine(MoveCoroutine(_dir));
    }

    IEnumerator MoveCoroutine(string _dir)
    {
        vector.Set(0, 0, vector.z);

        switch(_dir)
        {
            case "UP":
                vector.y = 1f;
                break;
            case "DOWN":
                vector.y = -1f;
                break;
            case "RIGHT":
                vector.x = 1f;
                break;
            case "LEFT":
                vector.x = -1f;
                break;
        }

        while(currentWalkCount < walkCount)
        {
            transform.Translate(vector.x * speed, vector.y * speed, 0);

            currentWalkCount++;
            yield return new WaitForSeconds(0.01f);
        }

        currentWalkCount = 0;
    }
}