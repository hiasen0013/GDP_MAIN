using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class System_Message_test : MonoBehaviour
{
    public static System_Message_test instance;
    [SerializeField] private UnityEngine.UI.Image sym_Panel;
    [SerializeField] private TextMeshProUGUI sym_text;
    public int sym_count = 0;
    public System_message[] syms;
    private bool isTyping = false;
    public float typingSpeed = 100f;
    public bool canNextsym = true; 


    private void Awake()
    {
        instance = this;
    }
    public void ShowSym()
    {
        SymUI_OnOff(true);
        TLS_Manager.instance.isDialog = true;
        sym_count = 0;
        NextSym();
    }

    private void NextSym()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            sym_text.text = syms[sym_count - 1].systemMsg;
            isTyping = false;
            return;
        }

        if (sym_count < syms.Length)
        {
            StartCoroutine(TypeEffect(syms[sym_count].systemMsg));
            sym_count++;
            //print("현재 대사의 카운터 :" + dialog_count);
        }
        else
        {
            SymUI_OnOff(false);
            TLS_Manager.instance.isDialog = false;
        }

        if (sym_count == 2)
        {
            Debug.Log("true");
            TLS_YesOrNo_prologue_0_0.instance.select_obj.SetActive(true);
        }
    }

    private IEnumerator TypeEffect(string text)
    {
        isTyping = true;
        sym_text.text = "";

        foreach (char c in text)
        {
            sym_text.text += c;
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false;
    }

    public void SymUI_OnOff(bool value)
    {
        sym_Panel.gameObject.SetActive(value);
        sym_text.gameObject.SetActive(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowSym();
        canNextsym  = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TLS_Manager.instance.isDialog && canNextsym)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                NextSym();
            }
        }
        Debug.Log("시스템 메세지 : "+sym_count);
    }
}

[System.Serializable]
public class System_message
{
    [TextArea]
    public string systemMsg;
}
