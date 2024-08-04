using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerManager : MovingObject_Ex
{
    static public PlayerManager instance;
  
    Rigidbody2D rigid;
    
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장

    public float runSpeed;
    private float applyRunSpeed;

    private bool canMove = true;

    private Coroutine moveCoroutine;

    // 2
    /////////////////////////////

    float h;
    float v;

    bool isHorizonMove;

    Vector2 lastDirection;

    /////////////////////////////
    
    GameObject scanObject;
    // public GameManager manager;

    public 오브젝트감지 obj;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {
        while (!canMove)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
            }
            else
            {
                applyRunSpeed = 0;
            }

            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);

            vector.Set(moveVec.x, moveVec.y, transform.position.z);

            if (vector.x != 0 || vector.y != 0)
            {
                animator.SetFloat("DirX", vector.x);
                animator.SetFloat("DirY", vector.y);

                lastDirection = new Vector2(vector.x, vector.y);  // 마지막 방향 저장

                /////////////////////////////

                // // bool CheckCollisionFlag = base.CheckCollision();
                // if (CheckCollisionFlag)
                // {
                //     animator.SetBool("Walking", false);
                //     break;
                // }

                /////////////////////////////

                animator.SetBool("Walking", true);

                transform.Translate(vector.x * (speed + applyRunSpeed) * Time.deltaTime, vector.y * (speed + applyRunSpeed) * Time.deltaTime, 0);
            }
            else
            {
                animator.SetBool("Walking", false);
                canMove = true;
                yield break;
            }

            yield return null;
        }
    }

    void Update()
    {   
        // 4
        /////////////////////////////
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (h != 0)
        {
            isHorizonMove = true;
        }
        else if (v != 0)
        {
            isHorizonMove = false;
        }

        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);

        /////////////////////////////

        if (canMove)
        {
            if (moveVec.x != 0 || moveVec.y != 0)
            {
                canMove = false;
                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }
                moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }
        else
        {
            vector.Set(moveVec.x, moveVec.y, transform.position.z);
            if (vector.x != 0 || vector.y != 0)
            {
                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }
                moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }

        ///////////////////////
        // if (Input.GetButtonDown("Jump") && scanObject != null)
        // {
        //     print(scanObject.name);
        //     obj.Action(scanObject);
        // }
        ///////////////////////
    }

    void FixedUpdate()
    {
        // 이동이 없을 때도 마지막 방향으로 Raycast 사용
        Vector2 direction = vector.x != 0 || vector.y != 0 ? new Vector2(vector.x, vector.y) : lastDirection;

        Debug.DrawRay(rigid.position, direction * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, direction, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
        }
    }

    public void ResetPlayerState()
    {
        h = 0;
        v = 0;
        isHorizonMove = false;
        rigid.velocity = Vector2.zero;
    }
}