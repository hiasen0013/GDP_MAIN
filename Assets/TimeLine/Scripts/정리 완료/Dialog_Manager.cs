using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialog_Manager : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image dialog_Panel;
    [SerializeField] private UnityEngine.UI.Image dialog_portrait;
    [SerializeField] private TextMeshProUGUI dialog_nameText;
    [SerializeField] private TextMeshProUGUI dialog_text;
    public int dialog_count = 0;
    [SerializeField]private Dialog[] dialogs;
    private bool isTyping = false;
    public float typingSpeed = 100f;

    public void ShowDialog()
    {
        DialogUI_OnOff(true);
        dialog_count = 0;
        NextDialog();
    }

    private void NextDialog()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialog_text.text = dialogs[dialog_count - 1].dialog;
            isTyping = false;
            return;
        }

        if (dialog_count < dialogs.Length)
        {
            StartCoroutine(TypeEffect(dialogs[dialog_count].dialog));
            dialog_portrait.sprite = dialogs[dialog_count].portrait;
            dialog_nameText.text = dialogs[dialog_count].dialog_name;
            dialog_count++;
            //print("현재 대사의 카운터 :" + dialog_count);
        }
        else
        {
            DialogUI_OnOff(false);
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeEffect(string text)
    {
        isTyping = true;
        dialog_text.text = "";

        foreach (char c in text)
        {
            dialog_text.text += c;
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false;
    }

    private void DialogUI_OnOff(bool value)
    {
        dialog_Panel.gameObject.SetActive(value);
        dialog_portrait.gameObject.SetActive(value);
        dialog_text.gameObject.SetActive(value);
        dialog_nameText.gameObject.SetActive(value);
        TLS_Manager.instance.isDialog = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowDialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (TLS_Manager.instance.isDialog)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextDialog();
            }
        }
    }
}

[System.Serializable]
public class Dialog
{
    [TextArea]
    public string dialog;
    public string dialog_name;
    public Sprite portrait;
}
