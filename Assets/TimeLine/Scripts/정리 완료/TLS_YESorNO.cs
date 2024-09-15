using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class TLS_YesorNo : MonoBehaviour
{
    [SerializeField] protected Button yesBtn;
    [SerializeField] protected Button noBtn;
    [SerializeField] protected Button selectedBtn;
    protected int yes_no_value = 0;

    protected virtual void Start()
    {
        selectedBtn = yesBtn;
        SetButtonTextColor(selectedBtn, Color.red);
        selectedBtn.Select();
    }
    
    protected virtual void ToggleBtn()
    {
        SetButtonTextColor(selectedBtn, Color.white);
        if(selectedBtn == yesBtn)
        {
            selectedBtn = noBtn;
            Debug.Log("No버튼");
        }
        else
        {
            selectedBtn = yesBtn;
            Debug.Log("YES버튼");
        }
        SetButtonTextColor(selectedBtn, Color.red);
        selectedBtn.Select();
    }

    protected void SetButtonTextColor(Button btn, Color color)
    {
        TextMeshProUGUI btnText = btn.GetComponentInChildren<TextMeshProUGUI>(true);
        if(btnText != null)
        {
            btnText.color = color;
        }
    }
}
