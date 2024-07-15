using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    // 씬 체크를 통한 제어를 위한 변수
    public string currentSceneName;

    // 씬별 이동 속도 설정을 위한 변수
    private float sceneMoveSpeed;

    /////////////////////////////////////////////////////////////

    // public BoxCollider2D bound;

    // // BoxCollider 영역의 최소 최대 xyz값을 지님
    // private Vector3 minBound;
    // private Vector3 maxBound;

    // // 카메라의 반너비, 반높이 값을 지닐 변수
    // private float halfWidth;
    // private float halfHeight;

    // // 카메라의 반높이 값을 구할 속성을 이용하기 위한 변수
    // private Camera theCamera;

    /////////////////////////////////////////////////////////////

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        UpdateSceneInfo();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSceneInfo();
    }

    void UpdateSceneInfo()
    {
        // 현재 씬 이름을 저장합니다.
        currentSceneName = SceneManager.GetActiveScene().name;

        // 씬별 이동 속도 및 위치 설정
        if (currentSceneName == "2_Left_Corridor")
        {
            // 2_Left_Corridor 씬인 경우
            target = GameObject.Find("Player");
            sceneMoveSpeed = 5.0f; // 원하는 이동 속도 설정
            moveSpeed = sceneMoveSpeed;
        }
        else if (currentSceneName == "1_Room")
        {
            // 1_Room 씬인 경우
            target = GameObject.Find("Player");
            sceneMoveSpeed = 0.0f; // 정지
            moveSpeed = sceneMoveSpeed;
            // 카메라 위치 고정
            this.transform.position = new Vector3(9, 0, -10);
            // print(transform.position);
        }
        else
        {
            // 기본 이동 속도 설정 (만약 씬별 설정이 없으면 기본값 사용)
            moveSpeed = sceneMoveSpeed;
        }
    }

    void Update()
    {
        if (target != null && currentSceneName != "1_Room")
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        else if(currentSceneName == "1_Room")
        {
            this.transform.position = new Vector3(9, 0, -10);
        }

        else if(currentSceneName == "1_RoomCutScene")
        {
            this.transform.position = new Vector3(9, 0, -10);
        }
    }
}