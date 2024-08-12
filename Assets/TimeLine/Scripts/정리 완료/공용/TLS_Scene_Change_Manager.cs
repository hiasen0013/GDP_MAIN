using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_First_TLS()
    {
        GameProgress.instance.prolog.prolog0_0 = true;
        if(GameProgress.instance.prolog.prolog0_0 == true)
        {
            SceneManager.LoadScene("지하_6층_배치도");
            Debug.Log("성공");
        }
    }

    public void End_Second_TLS()
    {
        if(SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("3_엘레베이터 안");
        }
        else if(!SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("3_엘레베이터 안");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2_엘레베이터 앞");
        }
    }
    

}