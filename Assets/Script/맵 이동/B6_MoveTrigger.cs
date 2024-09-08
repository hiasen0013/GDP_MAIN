using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private GameObject b6_Corridor_Left;
    [SerializeField] private GameObject b6_Corridor_Right;
    [SerializeField] private GameObject b6_lobby;
    [SerializeField] private GameObject b6_counseling_room;
    [SerializeField] private GameObject b6_laboratory;

    [SerializeField] private float testmovePos;

    protected override void Start()
    {
        base.Start();
        /*b6_Room_101.SetActive(false);
        b6_Room_102.SetActive(false);
        b6_Room_103.SetActive(true);
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
        b6_laboratory.SetActive(false); */
    }

    public override void OnChildTriggerEnter(Collider2D other, int childId)
    {
        switch (childId)
        {
            case 0: // 101룸에서 복도로
                Transform nextChildTransform0 = transform.GetChild(1);
                Vector2 newPosition0 = new Vector2(nextChildTransform0.position.x, nextChildTransform0.position.y - 0.8f);
                other.transform.position = newPosition0;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_101.SetActive(false);
                b6_Corridor_Left.SetActive(true);
                break;
            case 1: // 복도에서 101룸으로
                Transform nextChildTransform1 = transform.GetChild(0);
                Vector2 newPosition1 = new Vector2(nextChildTransform1.position.x, nextChildTransform1.position.y + 1.3f);
                other.transform.position = newPosition1;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_Room_101.SetActive(true);
                break;


            case 2: // 102룸에서 복도로
                Transform nextChildTransform2 = transform.GetChild(3);
                Vector2 newPosition2 = new Vector2(nextChildTransform2.position.x, nextChildTransform2.position.y - 0.8f);
                other.transform.position = newPosition2;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_102.SetActive(false);
                b6_Corridor_Left.SetActive(true);
                break;
            case 3: // 복도에서 102룸으로
                Transform nextChildTransform3 = transform.GetChild(2);
                Vector2 newPosition3 = new Vector2(nextChildTransform3.position.x, nextChildTransform3.position.y + 1.3f);
                other.transform.position = newPosition3;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_Room_102.SetActive(true);
                break;


            case 4: // 103룸에서 복도로
                Transform nextChildTransform4 = transform.GetChild(5);
                Vector2 newPosition4 = new Vector2(nextChildTransform4.position.x, nextChildTransform4.position.y - testmovePos);
                other.transform.position = newPosition4;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_103.SetActive(false);
                b6_Corridor_Left.SetActive(true);

                if(GameProgress.instance.tlProgress.prolog0_0)
                {
                    SceneManager.LoadSceneAsync("0_문앞_오츠도망");
                    GameProgress.instance.tlProgress.prolog0_1 = true;
                }
                break;
            case 5: // 복도에서 103룸으로
                Transform nextChildTransform5 = transform.GetChild(4);
                Vector2 newPosition5 = new Vector2(nextChildTransform5.position.x, nextChildTransform5.position.y + 1.5f);
                other.transform.position = newPosition5;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_Room_103.SetActive(true);
                break;


            case 6: // 104룸에서 복도로
                Transform nextChildTransform6 = transform.GetChild(7);
                Vector2 newPosition6 = new Vector2(nextChildTransform6.position.x, nextChildTransform6.position.y - 1f);
                other.transform.position = newPosition6;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_104.SetActive(false);
                b6_Corridor_Left.SetActive(true);
                break;
            case 7: // 복도에서 104룸으로
                Transform nextChildTransform7 = transform.GetChild(6);
                Vector2 newPosition7 = new Vector2(nextChildTransform7.position.x, nextChildTransform7.position.y + 1.5f);
                other.transform.position = newPosition7;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_Room_104.SetActive(true);
                break;


            case 8: // 105룸에서 복도로
                Transform nextChildTransform8 = transform.GetChild(9);
                Vector2 newPosition8 = new Vector2(nextChildTransform8.position.x, nextChildTransform8.position.y - 1f);
                other.transform.position = newPosition8;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_105.SetActive(false);
                b6_Corridor_Left.SetActive(true);
                break;
            case 9: // 복도에서 105룸으로
                Transform nextChildTransform9 = transform.GetChild(8);
                Vector2 newPosition9 = new Vector2(nextChildTransform9.position.x, nextChildTransform9.position.y + 1.5f);
                other.transform.position = newPosition9;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_Room_105.SetActive(true);
                break;


            case 10: // 201룸에서 복도로
                Transform nextChildTransform10 = transform.GetChild(11);
                Vector2 newPosition10 = new Vector2(nextChildTransform10.position.x, nextChildTransform10.position.y - 1f);
                other.transform.position = newPosition10;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_201.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;
            case 11: // 복도에서 201룸으로
                Transform nextChildTransform11 = transform.GetChild(10);
                Vector2 newPosition11 = new Vector2(nextChildTransform11.position.x, nextChildTransform11.position.y + 1.5f);
                other.transform.position = newPosition11;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_Room_201.SetActive(true);
                break;


            case 12: // 202룸에서 복도로
                Transform nextChildTransform12 = transform.GetChild(13);
                Vector2 newPosition12 = new Vector2(nextChildTransform12.position.x, nextChildTransform12.position.y - 1f);
                other.transform.position = newPosition12;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_202.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;
            case 13: // 복도에서 202룸으로
                Transform nextChildTransform13 = transform.GetChild(12);
                Vector2 newPosition13 = new Vector2(nextChildTransform13.position.x, nextChildTransform13.position.y + 1.5f);
                other.transform.position = newPosition13;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_Room_202.SetActive(true);
                break;


            case 14: // 203룸에서 복도로
                Transform nextChildTransform14 = transform.GetChild(15);
                Vector2 newPosition14 = new Vector2(nextChildTransform14.position.x, nextChildTransform14.position.y - 1f);
                other.transform.position = newPosition14;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_203.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;
            case 15: // 복도에서 203룸으로
                Transform nextChildTransform15 = transform.GetChild(14);
                Vector2 newPosition15 = new Vector2(nextChildTransform15.position.x, nextChildTransform15.position.y + 1.5f);
                other.transform.position = newPosition15;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_Room_203.SetActive(true);
                break;


            case 16: // 204룸에서 복도로
                Transform nextChildTransform16 = transform.GetChild(17);
                Vector2 newPosition16 = new Vector2(nextChildTransform16.position.x, nextChildTransform16.position.y - 1f);
                other.transform.position = newPosition16;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_204.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;
            case 17: // 복도에서 204룸으로
                Transform nextChildTransform17 = transform.GetChild(16);
                Vector2 newPosition17 = new Vector2(nextChildTransform17.position.x, nextChildTransform17.position.y + 1.5f);
                other.transform.position = newPosition17;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_Room_204.SetActive(true);
                break;


            case 18: // 205룸에서 복도로
                Transform nextChildTransform18 = transform.GetChild(19);
                Vector2 newPosition18 = new Vector2(nextChildTransform18.position.x, nextChildTransform18.position.y - 1f);
                other.transform.position = newPosition18;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Room_205.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;
            case 19: // 복도에서 205룸으로
                Transform nextChildTransform19 = transform.GetChild(18);
                Vector2 newPosition19 = new Vector2(nextChildTransform19.position.x, nextChildTransform19.position.y + 1.5f);
                other.transform.position = newPosition19;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_Room_205.SetActive(true);
                break;


            case 20: // 왼쪽복도에서 로비로
                Transform nextChildTransform20 = transform.GetChild(21);
                Vector2 newPosition20 = new Vector2(nextChildTransform20.position.x + 1f, nextChildTransform20.position.y);
                other.transform.position = newPosition20;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Left.SetActive(false);
                b6_lobby.SetActive(true);
                if(GameProgress.instance.tlProgress.prolog0_1)
                {
                    /*GameObject player = GameObject.Find("Player");
                    if(player != null)
                    {
                        player.transform.position = new Vector3(72.99f,20.7f,0f);
                        Debug.Log("위치조정 성공");
                    } */
                    SceneManager.LoadSceneAsync("0-2_엘레베이터_앞");
                }

                if(GameProgress.instance.tlProgress.prolog1_0)
                {
                    SceneManager.LoadSceneAsync("1-2_로비_엘레베이터_안");
                }
                break;
            case 21: // 로비에서 왼쪽복도로
                Transform nextChildTransform21 = transform.GetChild(20);
                Vector2 newPosition21 = new Vector2(nextChildTransform21.position.x - 1.5f, nextChildTransform21.position.y);
                other.transform.position = newPosition21;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_lobby.SetActive(false);
                b6_Corridor_Left.SetActive(true);
                break;


            case 22: // 오른쪽복도에서 로비로
                Transform nextChildTransform22 = transform.GetChild(23);
                Vector2 newPosition22 = new Vector2(nextChildTransform22.position.x - 1.5f, nextChildTransform22.position.y);
                other.transform.position = newPosition22;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_Corridor_Right.SetActive(false);
                b6_lobby.SetActive(true);
                break;
            case 23: // 로비에서 오른쪽복도
                Transform nextChildTransform23 = transform.GetChild(22);
                Vector2 newPosition23 = new Vector2(nextChildTransform23.position.x + 1f, nextChildTransform23.position.y);
                other.transform.position = newPosition23;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_lobby.SetActive(false);
                b6_Corridor_Right.SetActive(true);
                break;


            case 24: // 로비에서 상담실로
                Transform nextChildTransform24 = transform.GetChild(25);
                Vector2 newPosition24 = new Vector2(nextChildTransform24.position.x - 1.5f, nextChildTransform24.position.y);
                other.transform.position = newPosition24;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_lobby.SetActive(false);
                b6_counseling_room.SetActive(true);
                break;
            case 25: // 상담실에서 로비로
                Transform nextChildTransform25 = transform.GetChild(24);
                Vector2 newPosition25 = new Vector2(nextChildTransform25.position.x + 1f, nextChildTransform25.position.y);
                other.transform.position = newPosition25;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_counseling_room.SetActive(false);
                b6_lobby.SetActive(true);
                break;


            case 26: // 로비에서 실험실로
                Transform nextChildTransform26 = transform.GetChild(27);
                Vector2 newPosition26 = new Vector2(nextChildTransform26.position.x + 1f, nextChildTransform26.position.y);
                other.transform.position = newPosition26;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_lobby.SetActive(false);
                b6_laboratory.SetActive(true);
                break;

            case 27: // 실험실에서 로비로
                Transform nextChildTransform27 = transform.GetChild(26);
                Vector2 newPosition27 = new Vector2(nextChildTransform27.position.x - 1.5f, nextChildTransform27.position.y);
                other.transform.position = newPosition27;
                Debug.Log($"{childId}번째 자식 오브젝트와 충돌하여 이동하였습니다.");
                b6_laboratory.SetActive(false);
                b6_lobby.SetActive(true);
                break;

        }
    }
}