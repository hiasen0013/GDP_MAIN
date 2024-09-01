using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TLS_YesorNo : MonoBehaviour
{
    public bool selecting = false;
    [SerializeField] protected GameObject select_obj;
    [SerializeField] protected Button yesBtn;
    [SerializeField] protected Button noBtn;
    [SerializeField] protected Button selectedBtn;
    protected int yes_no_value = 0;

    protected virtual void Start()
    {
        selectedBtn = yesBtn;
        SetButtonTextColor(selectedBtn, Color.red);
        selectedBtn.Select();
        yesBtn.onClick.AddListener(YesBtn_Click);
        noBtn.onClick.AddListener(NoBtn_Click);
    }
 
    public virtual void YesOrNo_obj(bool value)
    {
        select_obj.SetActive(value);
    }

    protected virtual void Update()
    {
        if(selecting)
        {
            YesOrNo_obj(true);
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleBtn();
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                selectedBtn.onClick.Invoke();
                Debug.Log("선택함");
                YesOrNo_obj(false);
            }
        }
    }
    
    protected virtual void YesBtn_Click()
    {
        yes_no_value = 1;
        YesOrNo_obj(false);
    }

    protected virtual void NoBtn_Click()
    {
        yes_no_value = 2;
        YesOrNo_obj(false);
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
