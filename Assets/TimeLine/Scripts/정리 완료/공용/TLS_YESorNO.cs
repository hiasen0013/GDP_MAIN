using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class TLS_YesorNo : MonoBehaviour
{
    protected bool selecting = true;
    [SerializeField] protected GameObject select_obj;
    [SerializeField] protected Button yesBtn;
    [SerializeField] protected Button noBtn;
    [SerializeField] protected Button selectedBtn;
    protected int yes_no_value = 0;

    protected virtual void Start()
    {
        selectedBtn = yesBtn;
        selectedBtn.Select();
    }
 
    protected virtual void YesOrNo_obj(bool value)
    {
        select_obj.SetActive(value);
        selecting = value;
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
                selectedBtn.onClick.Invoke();
                Debug.Log("선택함");
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
        if(selectedBtn == yesBtn)
        {
            selectedBtn = noBtn;
        }
        else
        {
            selectedBtn = yesBtn;
        }
        selectedBtn.Select();
    }
}
