using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutIn : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 1f; 

    void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void FadeOutInStart()
    {
        StartCoroutine(FadeOutInCoroutine());
    }

    public void FadeOutStart()
    {
        StartCoroutine(FadeOutInCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        yield return StartCoroutine(Fade(0, 1));
    }

    private IEnumerator FadeOutInCoroutine()
    {
        yield return StartCoroutine(Fade(0, 1));

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(Fade(1, 0));
    }

    private IEnumerator Fade(float startFade, float endFade)
    {
        float FadeTime = 0f;
        Color color = image.color;
        
        while (FadeTime < fadeDuration)
        {
            FadeTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startFade, endFade, FadeTime / fadeDuration);
            color.a = newAlpha;
            image.color = color;
            yield return null;
        }

        color.a = endFade;
        image.color = color;
    }
}