using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_0_First_TLS()
    {
        GameProgress.instance.tlProgress.prolog0_1 = true;
        if(GameProgress.instance.tlProgress.prolog0_1 == true)
        {
            SceneManager.LoadScene("지하_6층_배치도");
            Debug.Log("성공 프롤로그1 true");
        }

        if(SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
        else if(!SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
    }

    public void End_0_Second_TLS()
    {
        if(SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
        else if(!SystemMessage.instance.YorN)
        {
            SceneManager.LoadScene("0-3_엘레베이터_안");
        }
    }

    public void End_0_Thrid_TLS()
    {
        //GameProgress.instance.tlProgress.prolog0_3 = true;
        SceneManager.LoadScene("지하3층_배치도");
    }

    public void End_0_4_TLS()
    {
        SceneManager.LoadScene("지하3층_배치도");
    }

    public void End_0_5_TLS()
    {
        SceneManager.LoadScene("0-5_지하3층_상담실");
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