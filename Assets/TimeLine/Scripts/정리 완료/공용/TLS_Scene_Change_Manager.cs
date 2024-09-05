using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_0_1_TLS()
    {
        GameProgress.instance.tlProgress.prolog0_1 = true;
        if(GameProgress.instance.tlProgress.prolog0_1 == true)
        {
            SceneManager.LoadScene("지하_6층_배치도");
            Debug.Log("성공 프롤로그1 true");
        }
    }

    public void End_0_2_TLS()
    {
        SceneManager.LoadScene("0-3_엘레베이터_안");
        /*
        if(SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
        else if(!SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
        */
    }

    public void End_0_3_TLS()
    {
        GameProgress.instance.tlProgress.prolog0_2 = true;
        SceneManager.LoadScene("지하3층_배치도");
        
    }

    public void End_0_4_TLS()
    {
        GameProgress.instance.tlProgress.prolog0_2 = false;
        GameProgress.instance.tlProgress.prolog0_3 = true;
        SceneManager.LoadScene("지하3층_배치도");
    }

    public void End_0_5_TLS()
    {
        GameProgress.instance.tlProgress.prolog0_3 = false;
        SceneManager.LoadScene("지하_6층_배치도");
    }

    public void End_1_1_TLS()
    {
        SceneManager.LoadScene("1-1_프롤로그0");
    }

    public void End_1_2_TLS()
    {
        SceneManager.LoadScene("1-2_로비_엘레베이터_안");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2_엘레베이터 앞");
        }
    }

    public void End_0_Oates_Run_TLS()
    {
        SceneManager.LoadScene("지하_6층_배치도");
        GameProgress.instance.tlProgress.prolog0_0 = false;
        GameProgress.instance.tlProgress.prolog0_1 = true;
    }
}