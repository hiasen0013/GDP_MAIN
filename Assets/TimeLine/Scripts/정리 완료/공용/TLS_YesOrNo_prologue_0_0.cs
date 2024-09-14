using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_YesOrNo_prologue_0_0 : TLS_YesorNo
{
    public static TLS_YesOrNo_prologue_0_0 instance;
    [SerializeField] private GameObject oatesCutScene;
    public GameObject select_obj;

    public void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //if(selecting)
        //{
            //Select_Obj(true);
            
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
                    Debug.Log("예 클릭");
                    select_obj.SetActive(false);

                }
                else if (selectedBtn == noBtn)
                {
                    yes_no_value = 2;
                    Debug.Log("아니요 클릭");
                    select_obj.SetActive(false);

                }
            }
        //}

        //else if (!selecting)
        //{
            //Select_Obj(false);
        //}

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
