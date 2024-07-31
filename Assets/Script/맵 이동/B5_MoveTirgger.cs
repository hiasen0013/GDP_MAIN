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

    protected override void Start()
    {
        base.Start();
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
        switch(childId)
        {
            case 0: //특보실에서 중앙으로
                Transform nextChildTransform0 = transform.GetChild(1);
                Vector2 newPosition0 = new Vector2(nextChildTransform0.position.x + 2f, nextChildTransform0.position.y);
                other.transform.position = newPosition0;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Specialized_Laboratory.SetActive(false);
                b5_Center.SetActive(true);
                break;
            case 1: //중앙에서 특보실로
                Transform nextChildTransform1 = transform.GetChild(0);
                Vector2 newPosition1 = new Vector2(nextChildTransform1.position.x - 2f, nextChildTransform1.position.y);
                other.transform.position = newPosition1;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Center.SetActive(false);
                b5_Specialized_Laboratory.SetActive(true);
                break;


            case 2: // 중앙에서 분리실로
                Transform nextChildTransform2 = transform.GetChild(3);
                Vector2 newPosition2 = new Vector2(nextChildTransform2.position.x + 2f, nextChildTransform2.position.y);
                other.transform.position = newPosition2;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Center.SetActive(false);
                b5_Separation_Room.SetActive(true);
                break;
            case 3: // 분리실에서 중앙으로
                Transform nextChildTransform3 = transform.GetChild(2);
                Vector2 newPosition3 = new Vector2(nextChildTransform3.position.x - 2f, nextChildTransform3.position.y);
                other.transform.position = newPosition3;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Separation_Room.SetActive(false);
                b5_Center.SetActive(true);
                break;

            
            case 4: // 중앙에서 중앙아래로
                Transform nextChildTransform4 = transform.GetChild(5);
                Vector2 newPosition4 = new Vector2(nextChildTransform4.position.x, nextChildTransform4.position.y - 2f);
                other.transform.position = newPosition4;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Center.SetActive(false);
                b5_Center_Under.SetActive(true);
                break;
            case 5: // 중앙아래에서 중앙으로
                Transform nextChildTransform5 = transform.GetChild(4);
                Vector2 newPosition5 = new Vector2(nextChildTransform5.position.x, nextChildTransform5.position.y + 2f);
                other.transform.position = newPosition5;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Center_Under.SetActive(false);
                b5_Center.SetActive(true);
                break;


            case 6: // 특보실에서 실험체로
                Transform nextChildTransform6 = transform.GetChild(7);
                Vector2 newPosition6 = new Vector2(nextChildTransform6.position.x, nextChildTransform6.position.y - 2f);
                other.transform.position = newPosition6;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Specialized_Laboratory.SetActive(false);
                b5_Laboratory.SetActive(true);
                break;
            case 7: // 실험실에서 특보실로
                Transform nextChildTransform7 = transform.GetChild(6);
                Vector2 newPosition7 = new Vector2(nextChildTransform7.position.x, nextChildTransform7.position.y + 2f);
                other.transform.position = newPosition7;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b5_Laboratory.SetActive(false);
                b5_Specialized_Laboratory.SetActive(true);
                break;


        }
    }
}
