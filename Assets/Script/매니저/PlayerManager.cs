using System.Collections;
using UnityEngine;

public class PlayerManager : MovingObject_Ex
{
    static public PlayerManager instance;
  
    Rigidbody2D rigid;
    
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장

    public float runSpeed;
    private float applyRunSpeed;

    private bool canMove = true;
    private bool isFading = false; // 페이드 상태를 나타내는 플래그

    private Coroutine moveCoroutine;

    float h;
    float v;

    bool isHorizonMove;

    Vector2 lastDirection;

    GameObject scanObject;
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
            if (isFading) // 페이드 중에는 움직이지 않음
            {
                animator.SetBool("Walking", false); // 애니메이션 정지
                yield return null;
                continue;
            }
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

        if (canMove && !isFading)
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
            vector.Set(moveVec.x, vector.y, transform.position.z);
            if (vector.x != 0 || vector.y != 0)
            {
                if (moveCoroutine != null)
                {
                    StopCoroutine(moveCoroutine);
                }
                moveCoroutine = StartCoroutine(MoveCoroutine());
            }
        }
    }

    void FixedUpdate()
    {
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

    public void SetFadingState(bool fading)
    {
        isFading = fading; // 페이드 상태 설정
        if (isFading)
        {
            animator.SetBool("Walking", false); // 페이드 중에는 애니메이션 정지
        }
    }
}