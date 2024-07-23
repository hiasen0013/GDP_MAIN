using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B5_MoveTirgger : MoveTrigger
{
    [Header("맵 타일 및 오브젝트")]
    [SerializeField] private GameObject b5_Center;
    [SerializeField] private GameObject b5_Specialized_Laboratory;
    [SerializeField] private GameObject b5_Laboratory;
    [SerializeField] private GameObject b5_Center_Under;
    [SerializeField] private GameObject b5_Separation_Room;

    void Awaek()
    {
        if(b5_Center == null)
        {
            b5_Center = GameObject.Find("B5_중앙");
        }
        if(b5_Specialized_Laboratory == null)
        {
            b5_Specialized_Laboratory = GameObject.Find("B5_특보실");
        }
        if(b5_Laboratory == null)
        {
            b5_Laboratory = GameObject.Find("B5_실험실");
        }
        if(b5_Center_Under == null)
        {
            b5_Center_Under = GameObject.Find("B5_중앙_아래");
        }
        if(b5_Separation_Room == null)
        {
            b5_Separation_Room = GameObject.Find("B5_분리실");
        }
        b5_Specialized_Laboratory.SetActive(true);
        b5_Center.SetActive(false);
        b5_Laboratory.SetActive(false);
        b5_Center_Under.SetActive(false);
        b5_Separation_Room.SetActive(false);
    }

    public override void OnChildTriggerEnter(Collider2D other, int childId)
    {
        if(childId == 0) // 특보실에서 중앙으로
        {
            Transform nextChildTransform = transform.GetChild(1);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Specialized_Laboratory.SetActive(false);
            b5_Center.SetActive(true);
        }
        if(childId == 1) // 중앙에서 특보실로
        {
            Transform nextChildTransform = transform.GetChild(0);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Center.SetActive(false);
            b5_Specialized_Laboratory.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 2) // 중앙에서 분리실로
        {
            Transform nextChildTransform = transform.GetChild(3);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x + 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Center.SetActive(false);
            b5_Separation_Room.SetActive(true);
        }
        if(childId == 3) // 분리실에서 중앙으로
        {
            Transform nextChildTransform = transform.GetChild(2);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x - 2f, nextChildTransform.position.y);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Separation_Room.SetActive(false);
            b5_Center.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 4) // 중앙에서 중앙아래로
        {
            Transform nextChildTransform = transform.GetChild(5);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Center.SetActive(false);
            b5_Center_Under.SetActive(true);
        }

        if(childId == 5) // 중앙아래에서 중앙으로
        {
            Transform nextChildTransform = transform.GetChild(4);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Center_Under.SetActive(false);
            b5_Center.SetActive(true);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if(childId == 6) // 특보실에서 실험실로
        {
            Transform nextChildTransform = transform.GetChild(7);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y - 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Specialized_Laboratory.SetActive(false);
            b5_Laboratory.SetActive(true);
        }

        if(childId == 7) // 실험실에서 특보실로
        {
            Transform nextChildTransform = transform.GetChild(6);
            Vector2 newPosition = new Vector2(nextChildTransform.position.x, nextChildTransform.position.y + 2f);
            other.transform.position = newPosition;
            Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
            b5_Laboratory.SetActive(false);
            b5_Specialized_Laboratory.SetActive(true);
        }
    }
}
