using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SystemMessage : MonoBehaviour
{
    public static SystemMessage instance;
    public TextMeshProUGUI system_msg_text;
    [SerializeField] private UnityEngine.UI.Image dialog_box;
    bool isSpace = true;

    [SerializeField] private GameObject oatesCutScene;
    public bool YorN = false;
    public void System_MessageOnOff(bool value)
    {
        system_msg_text.gameObject.SetActive(value);
        dialog_box.gameObject.SetActive(value);
        TLS_Manager.instance.isDialog = value;
    }

    void OnEnable()
    {
        if(this.gameObject.activeSelf)
        {
            System_MessageOnOff(true);
            TLS_Sequence_Manager.instance.system_msg_count ++;
        }

        switch(TLS_Sequence_Manager.instance.system_msg_count)
        {
            case 0: system_msg_text.text =
            "";
            break;

            case 3: system_msg_text.text =
            "안나가 방을 나선 후 통 유리 앞에서 누군가의 시선이 느껴진다.";
            break;

            case 4: system_msg_text.text =
            "자세히 볼까?";
            isSpace = false;
            break;

            case 5 : oatesCutScene.SetActive(true);
            if(YorN == false)
            {
                TLS_Sequence_Manager.instance.system_msg_count++;
            }
            break;

            case 6: system_msg_text.text =
            "자세히 들여다보니 허리까지 내려오는 하얀 긴 머리를 하고 있는 사람이 자신이 시선이 들켰다고 생각했는지 후다닥-. 도망간다. ";
            TLS_Sequence_Manager.instance.system_msg_count++;
            break;

            case 7: system_msg_text.text =
            "자세히 들여보지 않았지만 하얀 머리의 사람이 계속해서 지켜보고 있는 것이 느껴진다. ";
            isSpace = false;
            break;

            case 8: print(TLS_Sequence_Manager.instance.system_msg_count);
            system_msg_text.text =
            "따라 갈까?";
            isSpace = false;
            break;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isSpace && !TLS_YesOrNo_prologue_0_0.instance.isSelecting)
        {
            System_MessageOnOff(false);
            oatesCutScene.SetActive(false); 
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isSpace && TLS_Sequence_Manager.instance.system_msg_count == 7)
        {
            system_msg_text.text =
            "그 형체는 몇 초간 더 지켜보더니 후다닥-. 사라진다.";
            isSpace = true;
        }
    }

    void Awake()
    {
        instance = this;
    }
}