using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// 이 스크립트는 게임의 진행도를 체크하기 위한 것이다.
public class GameProgress : MonoBehaviour
{
    public static GameProgress instance;
    public TimeLineProgress tlProgress {get; private set;} = new TimeLineProgress();
    public Yes_No_Progress ynProgress {get; private set;} = new Yes_No_Progress();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 씬은 : {scene.name} 입니다.");
    }
}

public class TimeLineProgress
{
    [Header("프롤로그 0 진행상황")] // 프롤로그 0, 엘베 앞, 엘베 안, 도서관, 상담실
    public bool prolog0_0 = true; // 프롤로그0이 끝나면 트루. 해리 방 앞의 오츠가 도망가면 폴스.
    public bool prolog0_1 = false; // 해리 방 앞의 오츠가 도망가면 트루. 엘베 앞으로 타임라인 끝나면 폴스.
    public bool prolog0_2 = false; // 엘베 앞 오츠를 따라가면 트루. 엘베 안 타임라인 끝나면 폴스.
    public bool prolog0_3 = false; // 보류
}

public class Yes_No_Progress
{
    [Header("프롤로그 0 선택지")] // 프롤로그 0, 엘베 앞
    public int prolog0_0_yn = 0;
    public int prolog0_2_yn = 0;
}
