using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop, FadeOutIn }

public class FadeEffect : MonoBehaviour
{
    
    [SerializeField]
    [Range(0.01f, 10f)]

    public float fadeTime;
    [SerializeField]
    private AnimationCurve fadeCurve;

    private Image image;

    public FadeState fadeState;

    private Coroutine currentCoroutine;

    void Awake()
    {
        image = GetComponent<Image>();   
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Onfade(FadeState.FadeIn); // or any other default fade state you want
    }
    public void Onfade(int state)
    {
        Onfade((FadeState)state);
    }

    public void Onfade(FadeState state)
    {
        fadeState = state;

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        switch(fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;    
            case FadeState.FadeInOut:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
            case FadeState.FadeOutIn:
                StartCoroutine(FadeOutIn());
                break;
        }
    }

    private IEnumerator FadeInOut()
    {
        while(true)
        {
            yield return StartCoroutine(Fade(1, 0)); 
            yield return StartCoroutine(Fade(0, 1)); 

            if(fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    private IEnumerator FadeOutIn()
    {
        while(true)
        {
            yield return StartCoroutine(Fade(0, 1)); 
            yield return StartCoroutine(Fade(1, 0)); 

            if(fadeState == FadeState.FadeOutIn)
            {
                break;
            }
        }
    }
    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;
        }
    }
}
