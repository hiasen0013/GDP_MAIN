using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCMove
{
    public bool NPCmove;

    public string[] direction;

    [Range(1, 5)]
    public int frequency;
}

public class NpcManager : MovingObject_Ex
{
    [SerializeField]
    public NPCMove npc;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    public void SetMove()
    {
        // 추후에 필요 시 SetMove 함수에 스크립트 작성
    }

    public void SetNotMove()
    {
        // 추후에 필요 시 SetNotMove 함수에 스크립트 작성
    }

    IEnumerator MoveCoroutine()
    {
        if(npc.direction.Length != 0)
        {
            for(int i = 0; i < npc.direction.Length; i++)
            {
                switch(npc.frequency)
                {
                    case 1:
                        yield return new WaitForSeconds(4f);
                        break;
                    case 2:
                        yield return new WaitForSeconds(3f);
                        break;
                    case 3:
                        yield return new WaitForSeconds(2f);
                        break;
                    case 4:
                        yield return new WaitForSeconds(1f);
                        break;
                    case 5:
                        break;
                }

                yield return new WaitUntil(() => npcCanMove);
                base.Move(npc.direction[i], npc.frequency);

                // if(i == npc.direction.Length - 1)
                // {
                //     i = -1;
                // }
            }
            animator.SetBool("Walking", false);
        }
    }
}