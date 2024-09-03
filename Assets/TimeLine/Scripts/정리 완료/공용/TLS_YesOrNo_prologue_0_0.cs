using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_YesOrNo_prologue_0_0 : TLS_YesorNo
{
    public static TLS_YesOrNo_prologue_0_0 instance;
    [SerializeField] private GameObject oatesCutScene;

    public void Awake()
    {
        instance = this;
    }

    protected override void Update()
    {
        Debug.Log(selecting);
        if(selecting)
        {
            Select_Obj(true);
            
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleBtn();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                //selectedBtn.onClick.Invoke();
                if(selectedBtn == yesBtn)
                {
                    yes_no_value = 1;
                    selecting = false;
                    //System_Message_test.instance.SymUI_OnOff(false);
                }
                else if (selectedBtn == noBtn)
                {
                    yes_no_value = 2;
                }
            }
        }

        else if (!selecting)
        {
            Select_Obj(false);
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
        public void Select_Obj_true()
        {
            Select_Obj(true);
        }
}
