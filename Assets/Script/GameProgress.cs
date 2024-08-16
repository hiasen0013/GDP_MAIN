using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress instance;
    // 이 스크립트는 타임라인의 진행도를 체크하기 위한 것이다.
    public PrologState prolog {get; private set;} = new PrologState();

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
        if(prolog.prolog0_1)
        {
            Debug.Log("프롤로그0-1이 트루");
        }
        return;
    }
}

public class PrologState
{
    [Header("프롤로그 0")] // 프롤로그 0, 엘베 앞, 엘베 안, 도서관, 상담실
    public bool prolog0_0 = false; // 프롤로그0이 끝나면 트루. 해리 방 앞의 오츠가 도망가면 폴스.
    public bool prolog0_1 = true; // 해리 방 앞의 오츠가 도망가면 트루. 엘베 앞으로 가면 폴스.
    public bool prolog0_2 = false; // 엘베 앞 오츠를 따라가면 트루. 엘베 안 타임라인 끝나면 폴스.
    public bool prolog0_3 = false; // 보류
}
