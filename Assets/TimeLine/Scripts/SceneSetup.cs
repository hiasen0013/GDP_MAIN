using UnityEngine;
using UnityEngine.Playables;

public class SceneSetup : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject scenePlayer; // 두 번째 씬의 타임라인 플레이어
    private GameObject existingPlayer; // 첫 번째 씬에서 넘어온 플레이어

    void Start()
    {
        // 첫 번째 씬에서 넘어온 플레이어 오브젝트 가져오기
        existingPlayer = GameObject.FindWithTag("Player");

        if (existingPlayer != null)
        {
            // 첫 번째 씬에서 넘어온 플레이어 비활성화
            existingPlayer.SetActive(false);

            // 타임라인 애니메이션이 끝났을 때 이벤트 등록
            playableDirector.stopped += OnPlayableDirectorStopped;
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        if (director == playableDirector)
        {
            // 첫 번째 씬에서 넘어온 플레이어 활성화
            existingPlayer.SetActive(true);

            // 두 번째 씬의 타임라인 플레이어 비활성화
            scenePlayer.SetActive(false);
        }
    }
}
