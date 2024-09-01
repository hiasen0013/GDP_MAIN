using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;

public class TLS_YesorNo : MonoBehaviour
{
    public bool selecting = false;
    public GameObject select_obj;
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

    protected virtual void Select_Obj(bool value)
    {
        select_obj.gameObject.SetActive(value);
        yesBtn.gameObject.SetActive(value);
        noBtn.gameObject.SetActive(value);
    }


    protected virtual void Update()
    {
        if(selecting)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleBtn();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(selectedBtn == yesBtn)
                {
                    yes_no_value = 1;
                    select_obj.SetActive(false);
                    selecting = false;
                }
                else if (selectedBtn == noBtn)
                {
                    yes_no_value = 2;
                    select_obj.SetActive(false);
                }
            }
        }
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
