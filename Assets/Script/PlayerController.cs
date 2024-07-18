using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;
    public string currentMapName; // transferMap 스크립트에 있는 transferMapName 변수의 값을 저장

    float h;
    float v;
    public float moveSpeed = 10;

    bool isHorizonMove;

    Vector3 dirVec;

    Rigidbody2D rigid;
    Animator anim;
    GameObject scanObject;

    private SpriteRenderer spr;

    public GameManager manager;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // void Update()
    // {
    //     {
    //         h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
    //         v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

    //         bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
    //         bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
    //         bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
    //         bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");                                                                                                                               

    //         if(hDown)
    //         {
    //             isHorizonMove = true;
    //         }
    //         else if(vDown)
    //         {
    //             isHorizonMove = false;
    //         }
    //         else if(hUp || vUp)
    //         {
    //             isHorizonMove = h != 0;
    //         }

    //         if(anim.GetInteger("hAxisRaw") != h)
    //         {
    //             anim.SetBool("isChange", true);
    //             anim.SetInteger("hAxisRaw", (int)h);
    //         }
    //         // else if(anim.GetInteger("vAxisRaw") != v)
    //         // {
    //         //     anim.SetBool("isChange", true);
    //         //     anim.SetInteger("vAxisRaw", (int)v);
    //         // }
    //         else
    //         {
    //             anim.SetBool("isChange", false);
    //         }

    //         if(vDown && v == 1)
    //         {
    //             dirVec = Vector3.up;
    //         }
    //         else if (vDown && v == -1)
    //         {
    //             dirVec = Vector3.down;
    //         }
    //         else if (hDown && h == -1)
    //         {
    //             dirVec = Vector3.left;
    //         }
    //         else if (hDown && h == 1)
    //         {
    //             dirVec = Vector3.right;
    //         }

    //         if(Input.GetButtonDown("Jump") && scanObject != null)
    //         {
    //             manager.Action(scanObject);
    //         }
    //     }
    // }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * moveSpeed;

        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null)
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
        anim.SetBool("isChange", false);
    }
}