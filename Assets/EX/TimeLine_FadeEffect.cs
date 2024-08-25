using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine_FadeEffect : MonoBehaviour
{
    private Image image;
    [SerializeField] private bool tls_fade_in = false;
    [SerializeField] private bool tls_fade_out = false;
    [SerializeField] private float fadeDuration = 2f;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        //tls_fade_in_start();
        tls_fade_out_start();
    }
    public void tls_fade_in_start()
    {
        tls_fade_in = true;
        StartCoroutine(TLS_Fade_In());
    }

    public void tls_fade_out_start()
    {
        tls_fade_out = true;
        StartCoroutine(TLS_Fade_Out());
    }

    private IEnumerator TLS_Fade_In()
    {
        float elapsedTime = 0f;
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        
        while(tls_fade_in && elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            image.color = color;
            yield return null;
        }
        tls_fade_in = false;
    }

    private IEnumerator TLS_Fade_Out()
    {
        float elapsedTime = 0f;
        Color color = image.color;
        color.a = 1f;
        image.color = color;


        while (tls_fade_out && elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1f - (elapsedTime / fadeDuration));
            image.color = color;
            yield return null;
        }
        tls_fade_out = false;
    }
}
