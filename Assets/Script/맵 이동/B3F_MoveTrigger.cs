using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3F_MoveTrigger : MoveTrigger
{
    [Header("맵 타일 및 오브젝트")]
    [SerializeField] private GameObject b3_Lobby;
    [SerializeField] private GameObject b3_Library;
    [SerializeField] private GameObject b3_Corridor;
    [SerializeField] private GameObject b3_Cafeteria;
    [SerializeField] private GameObject b3_CounselingRoom;
    [SerializeField] private GameObject b3_Warehouse;
    protected override void Start()
    {
        base.Start();

        if(b3_Lobby == null)
        {
            b3_Lobby = GameObject.Find("B3_로비");
        }

        if(b3_Library == null)
        {
            b3_Library = GameObject.Find("B3_도서관");
        }
        
        if(b3_Corridor == null)
        {
            b3_Corridor = GameObject.Find("B3_복도");
        }

        if(b3_Cafeteria == null)
        {
            b3_Cafeteria = GameObject.Find("B3_식당");
        }

        if(b3_CounselingRoom == null)
        {
            b3_CounselingRoom = GameObject.Find("B3_상담실");
        }
        if(b3_Warehouse == null)
        {
            b3_Warehouse = GameObject.Find("B3_창고");
        }
        b3_Lobby.SetActive(true); 
        b3_Library.SetActive(false); 
        b3_Corridor.SetActive(false); 
        b3_Cafeteria.SetActive(false); 
        b3_CounselingRoom.SetActive(false);
        b3_Warehouse.SetActive(false);
    }

    public override void OnChildTriggerEnter(Collider2D other, int childId)
    {
        switch(childId)
        {
            case 0: // 상담실에서 복도로
                Transform nextChildTransform0 = transform.GetChild(1);
                Vector2 newPosition0 = new Vector2(nextChildTransform0.position.x, nextChildTransform0.position.y - 2f);
                other.transform.position = newPosition0;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_CounselingRoom.SetActive(false);
                b3_Corridor.SetActive(true);
                break;
            case 1: // 복도에서 상담실로
                Transform nextChildTransform1 = transform.GetChild(0);
                Vector2 newPosition1 = new Vector2(nextChildTransform1.position.x, nextChildTransform1.position.y + 2f);
                other.transform.position = newPosition1;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Corridor.SetActive(false);
                b3_CounselingRoom.SetActive(true);
                break;


            case 2: // 재활치료실에서 복도로
                Transform nextChildTransform2 = transform.GetChild(3);
                Vector2 newPosition2 = new Vector2(nextChildTransform2.position.x, nextChildTransform2.position.y - 2f);
                other.transform.position = newPosition2;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Corridor.SetActive(true);
                break;
            case 3: // 복도에서 재활치료실로
                Transform nextChildTransform3 = transform.GetChild(2);
                Vector2 newPosition3 = new Vector2(nextChildTransform3.position.x, nextChildTransform3.position.y + 2f);
                other.transform.position = newPosition3;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Corridor.SetActive(false);
                break;


            case 4: // 복도에서 로비로
                Transform nextChildTransform4 = transform.GetChild(5);
                Vector2 newPosition4 = new Vector2(nextChildTransform4.position.x + 2f, nextChildTransform4.position.y);
                other.transform.position = newPosition4;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Corridor.SetActive(false);
                b3_Lobby.SetActive(true);
                break;
            case 5: // 로비에서 복도로
                Transform nextChildTransform5 = transform.GetChild(4);
                Vector2 newPosition5 = new Vector2(nextChildTransform5.position.x -2f, nextChildTransform5.position.y);
                other.transform.position = newPosition5;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Lobby.SetActive(false);
                b3_Corridor.SetActive(true);
                break;


            case 6: // 로비에서 도서관으로
                Transform nextChildTransform6 = transform.GetChild(7);
                Vector2 newPosition6 = new Vector2(nextChildTransform6.position.x + 2f, nextChildTransform6.position.y);
                other.transform.position = newPosition6;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Lobby.SetActive(false);
                b3_Library.SetActive(true);
                break;
            case 7: // 도서관에서 로비로
                Transform nextChildTransform7 = transform.GetChild(6);
                Vector2 newPosition7 = new Vector2(nextChildTransform7.position.x - 2f, nextChildTransform7.position.y);
                other.transform.position = newPosition7;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Library.SetActive(false);
                b3_Lobby.SetActive(true);
                break;


            case 8: //복도에서 식당으로
                Transform nextChildTransform8 = transform.GetChild(9);
                Vector2 newPosition8 = new Vector2(nextChildTransform8.position.x, nextChildTransform8.position.y - 2f);
                other.transform.position = newPosition8;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Corridor.SetActive(false);
                b3_Cafeteria.SetActive(true);
                break;
            case 9:
                Transform nextChildTransform9 = transform.GetChild(8);
                Vector2 newPosition9 = new Vector2(nextChildTransform9.position.x, nextChildTransform9.position.y + 2f);
                other.transform.position = newPosition9;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Cafeteria.SetActive(false);
                b3_Corridor.SetActive(true);
                break;


            case 10:
                Transform nextChildTransform10 = transform.GetChild(11);
                Vector2 newPosition10 = new Vector2(nextChildTransform10.position.x - 2f, nextChildTransform10.position.y);
                other.transform.position = newPosition10;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Library.SetActive(false);
                b3_Warehouse.SetActive(true);
                SpriteRenderer spr = other.gameObject.GetComponent<SpriteRenderer>();
                Material sprLitD = Resources.Load<Material>("Materials/Sprite-Lit-Default");
                spr.material = sprLitD;
                break;
            case 11:
                Transform nextChildTransform11 = transform.GetChild(10);
                Vector2 newPosition11 = new Vector2(nextChildTransform11.position.x + 2f, nextChildTransform11.position.y);
                other.transform.position = newPosition11;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b3_Warehouse.SetActive(false);
                b3_Library.SetActive(true);
                spr = other.gameObject.GetComponent<SpriteRenderer>();
                sprLitD = Resources.Load<Material>("Materials/Sprite-Unlit-Default");
                spr.material = sprLitD;
                break;


        }
    }
}
