using UnityEngine;
using TMPro;
using System.Collections;

public class TypingEffectScript : MonoBehaviour
{
    // 타이핑 출력 텍스트 UI (TextMeshPro Text)
    public TMP_Text typingText;

    // 타이핑 효과 속도 (초당 출력 글자 수)
    public float typingSpeed = 100f;

    void Start()
    {
        // 타이핑 효과 시작
        StartCoroutine(TypeEffect(typingText.text));
    }

    IEnumerator TypeEffect(string text)
    {
        // 기존 텍스트 지우기
        typingText.text = "";

        // 한 글자씩 빠르게 출력
        foreach (char c in text)
        {
            typingText.SetText(typingText.text + c);
            yield return new WaitForSeconds(1f / typingSpeed);
        }
    }
}