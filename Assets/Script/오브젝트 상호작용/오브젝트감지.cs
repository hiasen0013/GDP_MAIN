using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class 오브젝트감지 : MonoBehaviour
{

    [SerializeField] private UnityEngine.UI.Image dialog_portrait;
    [SerializeField] private UnityEngine.UI.Image dialog_box;
    [SerializeField] private TextMeshProUGUI dialog_text;
    [SerializeField] private TextMeshProUGUI dialog_nameText;


    public TextMeshProUGUI talkText;
    public GameObject scanObject;

    private void DialogUI_OnOff(bool value)
    {
        dialog_box.gameObject.SetActive(value);
        dialog_portrait.gameObject.SetActive(value);
        dialog_text.gameObject.SetActive(value);
        dialog_nameText.gameObject.SetActive(value);
    }

    void Start()
    {
        DialogUI_OnOff(false);
    }

    

    public void Action(GameObject scanObj)
    {
        DialogUI_OnOff(true);
        scanObject = scanObj;
        talkText.text = "평범한 " + scanObject.name + "다.";
        DialogUI_OnOff(false);
    }
}