using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TLS_YesOrNo_prologue_0_0 : TLS_YesorNo
{
    public static TLS_YesOrNo_prologue_0_0 instance;
    [SerializeField] private GameObject oatesCutScene;
    public GameObject select_obj;
    public bool isSelecting = false;
    [SerializeField] private bool cutscene = false;

    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isSelecting && !cutscene) // 컷씬이 진행 중이 아닐 때 선택 상태를 처리
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleBtn();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (selectedBtn == yesBtn)
                {
                    yes_no_value = 1;
                    Debug.Log("예 클릭");
                    select_obj.SetActive(false);
                    System_Message_test.instance.SymUI_OnOff(false);
                    cutscene = true;  // 컷씬 상태를 true로 변경
                    oatesCutScene.SetActive(true);
                    StartCoroutine(DelayAfterSeletion(0.5f));
                }
                else if (selectedBtn == noBtn)
                {
                    yes_no_value = 2;
                    Debug.Log("아니요 클릭");
                    select_obj.SetActive(false);
                    System_Message_test.instance.SymUI_OnOff(false);
                    isSelecting = false;
                    TLS_Manager.instance.isDialog = false;
                }
            }
        }

        // 컷씬이 활성화된 상태일 때만 작동
        if (cutscene)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !isSelecting)
            {
                oatesCutScene.SetActive(false);
                TLS_Manager.instance.isDialog = false;
                cutscene = false; // 컷씬이 종료되면 false로 변경
                Debug.Log("컷씬 쪽 입력이 감지됨");
            } 
        }
    }

    private IEnumerator DelayAfterSeletion(float delay)
    {
        yield return new WaitForSeconds(delay);
        isSelecting = false;
        yield break;
    }
}