using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut_In : MonoBehaviour
{
    private Image fadeImage;
    public float fadeTime;
    public float fadeoutTime;

    void Start()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFadeCoroutine()
    {
        StartCoroutine(FadeOutIn());
    }

    private IEnumerator FadeOutIn()
    {
        yield return StartCoroutine(FadeOut());
        yield return new WaitForSeconds(fadeoutTime);
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        while(fadeImage.color.a > 0f)
        {
            Color color = fadeImage.color;
            color.a -= fadeTime*Time.deltaTime;
            fadeImage.color = color;
            Debug.Log("FadeOut");
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        while(fadeImage.color.a < 1f)
        {
            Color color = fadeImage.color;
            color.a += fadeTime * Time.deltaTime;
            fadeImage.color = color;
            Debug.Log("fadeIN");
            yield return null;
        }
    }
}
