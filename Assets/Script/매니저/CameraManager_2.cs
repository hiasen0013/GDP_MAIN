using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CameraManager_2 : MonoBehaviour
{
    static public CameraManager_2 instance;

    public GameObject target;
    public float moveSpeed;
    private Vector3 targetPosition;

    // 씬 체크를 통한 제어를 위한 변수
    [SerializeField] private string currentSceneName;

    // 씬별 이동 속도 설정을 위한 변수
    [SerializeField] private float sceneMoveSpeed;

    // 타겟의 태그 설정을 위한 변수
    [SerializeField] private string targetTag = "Player";

    // 카메라의 위치값 설정을 위한 변수
    [SerializeField] private Vector3 roomCameraPosition = new Vector3(9, 0, -10);

    // 타임라인 디렉터
    [SerializeField] private PlayableDirector playableDirector;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateSceneInfo();
        if (playableDirector != null)
        {
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if (playableDirector != null)
        {
            playableDirector.stopped -= OnPlayableDirectorStopped;
        }
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
            target = GameObject.FindWithTag(targetTag);
            sceneMoveSpeed = 5.0f; // 원하는 이동 속도 설정
            moveSpeed = sceneMoveSpeed;
        }
        else if (currentSceneName == "1_Room")
        {
            // 1_Room 씬인 경우
            target = GameObject.FindWithTag(targetTag);
            sceneMoveSpeed = 0.0f; // 정지
            moveSpeed = sceneMoveSpeed;
            // 카메라 위치 고정
            this.transform.position = roomCameraPosition;
        }
        else
        {
            // 기본 이동 속도 설정 (만약 씬별 설정이 없으면 기본값 사용)
            moveSpeed = sceneMoveSpeed;
        }
    }

    void Update()
    {
        if (target != null && currentSceneName != "1_Room" && currentSceneName != "1_RoomCutScene")
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        else if (currentSceneName == "1_Room" || currentSceneName == "1_RoomCutScene")
        {
            this.transform.position = roomCameraPosition;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (director == playableDirector)
        {
            // 타임라인이 끝난 후 새로운 타겟을 찾음
            target = GameObject.FindWithTag(targetTag);

            // CameraManager 스크립트 비활성화
            if (CameraManager.instance != null)
            {
                CameraManager.instance.enabled = false;
            }

            // 자신을 활성화
            this.enabled = true;
        }
    }
}
