using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using UnityEditor.SceneManagement;
using UnityEngine.AI;

public class TimeLineManager : MonoBehaviour
{

    public static TimeLineManager instance;
    public bool isDialog;
    //타임라인 컨트롤러
    private PlayableDirector playableDirector;
    public GameObject yes_btn;
    public GameObject no_btn;
    public GameObject System_YorN_textBox;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        isDialog = false;
    }

    void Update()
    {
        if(isDialog)
        {
            playableDirector.Pause();
        }
        else if(!isDialog)
        {
            playableDirector.Play();
        }
    }

    public void CutSceneEnd()
    {
        playableDirector.Stop();
        this.gameObject.SetActive(false);
        CutSceneManager.instance.is_First_CutScene = false;
        CutSceneManager.instance.is_Second_CutScene = false;
        CutSceneManager.instance.is_Thrid_CutScene = false;
    }

    public void BtnManager(bool value)
    {
        yes_btn.SetActive(value);
        no_btn.SetActive(value);
        System_YorN_textBox.SetActive(value);
    }
}