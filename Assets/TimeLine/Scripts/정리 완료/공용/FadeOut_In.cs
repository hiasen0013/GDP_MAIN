using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutIn : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 1f;
    private float originalAlpha;

    void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        originalAlpha = image.color.a;
    }

    public void FadeOutInStart()
    {
        StartCoroutine(FadeOutInCoroutine());
    }

    public void FadeOutStart()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine(bool wait = false)
    {   wait = true;
        yield return StartCoroutine(Fade(originalAlpha, 1));
        while(wait)
        {
            yield return null;
        }
        yield return StartCoroutine(Fade(1,0));
        
    }

    private IEnumerator FadeOutInCoroutine()
    {

        yield return StartCoroutine(Fade(originalAlpha, 1));

        yield return new WaitForSeconds(3f);

        yield return StartCoroutine(Fade(1, 0));
        
        Color color = image.color;
        color.a = originalAlpha;
        image.color = color;
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