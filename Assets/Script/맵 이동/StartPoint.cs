using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // 맵이 이동될 시, 플레이어가 시작될 위치

    private PlayerManager thePlayer;
    private CameraManager theCamera;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theCamera = FindObjectOfType<CameraManager>();

        if(startPoint == thePlayer.currentMapName)
        {
            theCamera.transform.position = new Vector3(0, 0, -10); // 씬이 시작될 때 카메라 위치 조정 가능
            thePlayer.transform.position = this.transform.position;
            thePlayer.ResetPlayerState(); // 플레이어 상태를 초기화
        }
    }
}
