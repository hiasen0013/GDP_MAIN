using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TLS_Scene_Change_Manager : MonoBehaviour
{
    public void End_First_TLS()
    {
        
        SceneManager.LoadScene("1_Room");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene("2_엘레베이터 앞");
        }
    }
}