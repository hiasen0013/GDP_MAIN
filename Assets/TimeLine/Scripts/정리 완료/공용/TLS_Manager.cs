using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class TLS_Manager : MonoBehaviour
{
    public static TLS_Manager instance;
    public bool isDialog;
    //타임라인 컨트롤러
    public PlayableDirector playableDirector;

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
        
        TLS_Sequence_Manager.instance.is_First_TLS = false;
        TLS_Sequence_Manager.instance.is_Second_TLS = false;
        TLS_Sequence_Manager.instance.is_Thrid_TLS = false;
    }
}