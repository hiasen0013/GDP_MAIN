using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_YesOrNo_prologue_0_0 : TLS_YesorNo
{
    public static TLS_YesOrNo_prologue_0_0 instance;
    [SerializeField] private GameObject oatesCutScene;
    [SerializeField] private GameObject sym_obj;

    public void Awake()
    {
        instance = this;
    }

    protected override void Update()
    { 
        if(selecting)
        {

            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleBtn();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                selecting = false;
                selectedBtn.onClick.Invoke();
                YesOrNo_obj(false);
                System_Message_test.instance.SymUI_OnOff(false);
                Debug.Log(yes_no_value);
            }
        }
        else
        {
            YesOrNo_obj(false);
            if(yes_no_value == 1)
            {
                oatesCutScene.SetActive(true);
            }
        }

        if(oatesCutScene.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                oatesCutScene.SetActive(false);
                TLS_Manager.instance.isDialog = false;
            }
        }
    }
}
