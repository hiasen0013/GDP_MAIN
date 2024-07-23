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
    void Awake()
    {
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
        if(childId == 0) // 상담실에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(1);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_CounselingRoom.SetActive(false);
            b3_Corridor.SetActive(true);
        }

        if(childId == 1) // 복도에서 상담실로
        {
            Transform nextChildTransform = transform.GetChild(0);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Corridor.SetActive(false);
            b3_CounselingRoom.SetActive(true);

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 2) // 재활치료실에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(3);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Corridor.SetActive(true);
        }

        if(childId == 3) // 복도에서 재활치료실로
        {
            Transform nextChildTransform = transform.GetChild(2);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Corridor.SetActive(false);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 4) // 복도에서 로비로
        {
            Transform nextChildTransform = transform.GetChild(5);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Corridor.SetActive(false);
            b3_Lobby.SetActive(true);
        }

        if(childId == 5) // 로비에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(4);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x -2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Lobby.SetActive(false);
            b3_Corridor.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 6) // 로비에서 도서관으로
        {
            Transform nextChildTransform = transform.GetChild(7);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Lobby.SetActive(false);
            b3_Library.SetActive(true);
        }
        
        if(childId == 7) // 도서관에서 로비로
        {
            Transform nextChildTransform = transform.GetChild(6);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Library.SetActive(false);
            b3_Lobby.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 8) // 복도에서 식당으로
        {
            Transform nextChildTransform = transform.GetChild(9);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Corridor.SetActive(false);
            b3_Cafeteria.SetActive(true);
        }

        if(childId == 9) // 식당에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(8);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Cafeteria.SetActive(false);
            b3_Corridor.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 10) // 도서관에서 창고로
        {
            Transform nextChildTransform = transform.GetChild(11);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Library.SetActive(false);
            b3_Warehouse.SetActive(true);
            SpriteRenderer spr = other.gameObject.GetComponent<SpriteRenderer>();
            Material sprLitD = Resources.Load<Material>("Materials/Sprite-Lit-Default");
            spr.material = sprLitD;
            
        }
        
        if(childId == 11) // 창고에서 도서관으로
        {
            Transform nextChildTransform = transform.GetChild(10);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b3_Warehouse.SetActive(false);
            b3_Library.SetActive(true);
            SpriteRenderer spr = other.gameObject.GetComponent<SpriteRenderer>();
            Material sprLitD = Resources.Load<Material>("Materials/Sprite-Unlit-Default");
            spr.material = sprLitD;
        }
    }
}
