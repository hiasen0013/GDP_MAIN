using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_0_1_TLS() //프롤로그 0
    {
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog0_1 = true;
        }
        SceneManager.LoadScene("지하_6층_배치도");
    }

    public void End_0_2_TLS() // 엘베앞
    {
        SceneManager.LoadScene("0-3_엘레베이터_안");
    }

    public void End_0_3_TLS() // 엘베안
    {
        GameObject player = GameObject.Find("Player");
        if(player != null)
        {
            player.transform.position = new Vector3(46f, -1f, 0f);
            Debug.Log("지하3층 스타트 위치조정 성공");
        }
        
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog0_2 = true;
        }
        SceneManager.LoadScene("지하3층_배치도");
    }

    public void End_0_4_TLS() // 도서관
    {
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog0_2 = false;
            GameProgress.instance.tlProgress.prolog0_3 = true;
        }
        SceneManager.LoadScene("지하3층_배치도");
    }

    public void End_0_5_TLS()
    {
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog0_3 = false;
        }
        SceneManager.LoadScene("1-1_프롤로그0");
    }

    public void End_1_1_TLS()
    {
        SceneManager.LoadScene("지하_6층_배치도");
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog1_0 = true;
        }
    }

    public void End_1_2_TLS()
    {
        SceneManager.LoadScene("1-2_로비_엘레베이터_안");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2_엘레베이터 앞");
        }
    }

    public void End_0_Oates_Run_TLS()
    {
        SceneManager.LoadScene("지하_6층_배치도");
        if(GameProgress.instance != null && GameProgress.instance.tlProgress != null)
        {
            GameProgress.instance.tlProgress.prolog0_0 = false;
            GameProgress.instance.tlProgress.prolog0_1 = true;
        }
    }
}