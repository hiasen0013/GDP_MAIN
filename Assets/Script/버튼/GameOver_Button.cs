using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Button : MonoBehaviour
{
    public void Quit()
    {
        // ������ ��忡�� ���� ���� ���
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ����� ���ӿ����� ���ø����̼��� �����մϴ�.
        Application.Quit();
#endif
    }
}