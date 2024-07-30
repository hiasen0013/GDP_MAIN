using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B6_MoveTirgger : MoveTrigger
{
    //[SerializeField] private float tp_distance;
    [Header("맵 타일 및 오브젝트")]
    [SerializeField] private GameObject b6_Room_101;
    [SerializeField] private GameObject b6_Room_102;
    [SerializeField] private GameObject b6_Room_103;
    [SerializeField] private GameObject b6_Room_104;
    [SerializeField] private GameObject b6_Room_105;
    [SerializeField] private GameObject b6_Room_201;
    [SerializeField] private GameObject b6_Room_202;
    [SerializeField] private GameObject b6_Room_203;
    [SerializeField] private GameObject b6_Room_204;
    [SerializeField] private GameObject b6_Room_205;
    [SerializeField] private GameObject b6_Corridor_1;
    [SerializeField] private GameObject b6_Corridor_2;
    [SerializeField] private GameObject b6_lobby;
    [SerializeField] private GameObject b6_counseling_room;
    [SerializeField] private GameObject b6_laboratory;

    protected override void Start()
    {
        base.Start();
        b6_Room_101.SetActive(true);
        b6_Room_102.SetActive(false);
        b6_Room_103.SetActive(false);
        b6_Room_104.SetActive(false);
        b6_Room_105.SetActive(false);
        b6_Room_201.SetActive(false);
        b6_Room_202.SetActive(false);
        b6_Room_203.SetActive(false);
        b6_Room_204.SetActive(false);
        b6_Room_205.SetActive(false);
        b6_Corridor_1.SetActive(false);
        b6_Corridor_2.SetActive(false);
        b6_lobby.SetActive(false);
        b6_counseling_room.SetActive(false);
        b6_laboratory.SetActive(false);
    }

    public override void OnChildTriggerEnter(Collider2D other, int childId)
    {
        if(childId == 0) // 101룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(1);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_101.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        if(childId == 1) // 복도에서 101룸으로
        {
            Transform nextChildTransform = transform.GetChild(0);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_Room_101.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 2) // 102룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(3);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_102.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        if(childId == 3) // 복도에서 102으로
        {
            Transform nextChildTransform = transform.GetChild(2);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_Room_102.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 4) // 103룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(5);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_103.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        if(childId == 5) // 복도에서 103룸으로
        {
            Transform nextChildTransform = transform.GetChild(4);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_Room_103.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 6) // 104룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(7);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_104.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        if(childId == 7) // 복도에서 104룸으로
        {
            Transform nextChildTransform = transform.GetChild(6);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_Room_104.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 8) // 105룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(9);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_105.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        if(childId == 9) // 복도에서 105룸으로
        {
            Transform nextChildTransform = transform.GetChild(8);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_Room_105.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 10) // 201룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(11);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_201.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        if(childId == 11) // 복도에서 201룸으로
        {
            Transform nextChildTransform = transform.GetChild(10);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_Room_201.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 12) // 202룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(13);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_202.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        if(childId == 13) // 복도에서 202룸으로
        {
            Transform nextChildTransform = transform.GetChild(12);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_Room_202.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 14) // 203룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(15);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_203.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        if(childId == 15) // 복도에서 203룸으로
        {
            Transform nextChildTransform = transform.GetChild(14);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_Room_203.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 16) // 204룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(17);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_204.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        if(childId == 17) // 복도에서 204룸으로
        {
            Transform nextChildTransform = transform.GetChild(16);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_Room_204.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 18) // 205룸에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(19);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 1f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Room_205.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        if(childId == 19) // 복도에서 205룸으로
        {
            Transform nextChildTransform = transform.GetChild(18);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 1.5f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_Room_205.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 20) // 복도에서 로비로
        {
            Transform nextChildTransform = transform.GetChild(21);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 1f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_1.SetActive(false);
            b6_lobby.SetActive(true);
        }
        if(childId == 21) // 로비에서 복도로
        {
            Transform nextChildTransform = transform.GetChild(20);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 1.5f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_lobby.SetActive(false);
            b6_Corridor_1.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 22) // 복도2에서 로비로
        {
            Transform nextChildTransform = transform.GetChild(23);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 1.5f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_Corridor_2.SetActive(false);
            b6_lobby.SetActive(true);
        }
        if(childId == 23) // 로비에서 복도2로
        {
            Transform nextChildTransform = transform.GetChild(22);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 1f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_lobby.SetActive(false);
            b6_Corridor_2.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 24) // 로비에서 상담실
        {
            Transform nextChildTransform = transform.GetChild(25);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 1.5f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_lobby.SetActive(false);
            b6_counseling_room.SetActive(true);
        }
        if(childId == 25) // 상담실에서 로비
        {
            Transform nextChildTransform = transform.GetChild(24);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 1f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_counseling_room.SetActive(false);
            b6_lobby.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 26) // 로비에서 실험실
        {
            Transform nextChildTransform = transform.GetChild(27);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 1f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_lobby.SetActive(false);
            b6_laboratory.SetActive(true);
        }
        if(childId == 27) // 실험실에서 로비
        {
            Transform nextChildTransform = transform.GetChild(26);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 1.5f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b6_laboratory.SetActive(false);
            b6_lobby.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    }
}