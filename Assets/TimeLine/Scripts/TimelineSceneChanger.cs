using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineSceneChanger : MonoBehaviour
{
    public PlayableDirector director; // 타임라인을 실행하는 Playable Director를 연결
    public string sceneName; // 이동할 씬의 이름

    void Start()
    {
        director.stopped += OnPlayableDirectorStopped; // 타임라인이 끝났을 때 호출될 메서드를 등록
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (aDirector == director)
        {
            SceneManager.LoadScene(sceneName); // 설정된 씬으로 이동
        }
    }
}