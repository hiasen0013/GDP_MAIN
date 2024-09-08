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

        if(tlProgress.prolog0_0)
            Debug.Log("0_0True");
        if(tlProgress.prolog0_1)
            Debug.Log("0_1True");
        if(tlProgress.prolog0_2)
            Debug.Log("0_2True");
        if(tlProgress.prolog0_3)
            Debug.Log("0_3True");
        if(tlProgress.prolog1_0)
            Debug.Log("1_0True");
    }
}

public class TimeLineProgress
{
    [Header("프롤로그 0 진행상황")] // 프롤로그 0,
    public bool prolog0_0 = true; // 
    public bool prolog0_1 = false; // 
    public bool prolog0_2 = true; // 
    public bool prolog0_3 = true; // 
    public bool prolog1_0 = false;
}

public class Yes_No_Progress
{
    [Header("프롤로그 0 선택지")] // 프롤로그 0, 엘베 앞
    public int prolog0_0_yn = 0;
    public int prolog0_2_yn = 0;
}
