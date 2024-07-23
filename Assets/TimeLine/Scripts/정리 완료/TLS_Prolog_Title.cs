using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TLS_Prolog_Title : MonoBehaviour
{
    [SerializeField] private Image title_box;
    [SerializeField] private TextMeshProUGUI title_text;

    private bool title_fade_start;
    void Start()
    {   
        title_fade_start = false;
    }

    void Update()
    {
        if(title_fade_start)
        {
            //color 프로퍼티는 a변수만 따로 set이 불가능해서 변수에 저장
            Color title_box_color = title_box.color;
            Color title_text_color = title_text.color;

            //알파a 값이 0보다 크면 알파 값 감소
            if(title_box_color.a > 0 && title_text_color.a > 0)
            {
                title_box_color.a -= Time.deltaTime;
                title_text_color.a -= Time.deltaTime;
            }

            //바뀐 색상 정보를 각 오브젝트의 color에 저장
            title_box.color = title_box_color;
            title_text.color = title_text_color;

            if(title_box_color.a == 0)
            {
                title_fade_start = false;
            }
        }

    }

    // Update is called once per frame
    public void Title_Fade()
    {
        title_fade_start = true;
    }
}