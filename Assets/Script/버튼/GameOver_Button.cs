using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Button : MonoBehaviour
{
    public void Quit()
    {
        // 에디터 모드에서 실행 중인 경우
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서는 애플리케이션을 종료합니다.
        Application.Quit();
#endif
    }
}