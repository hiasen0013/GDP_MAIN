using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_0_First_TLS()
    {
        GameProgress.instance.prolog.prolog0_1 = true;
        if(GameProgress.instance.prolog.prolog0_1 == true)
        {
            SceneManager.LoadScene("지하_6층_배치도");
            Debug.Log("성공 프롤로그1 true");
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
        //GameProgress.instance.prolog.prolog0_3 = true;
        SceneManager.LoadScene("지하3층_배치도");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2_엘레베이터 앞");
        }
    }
    

}