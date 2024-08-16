using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_GameProgress : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(GameProgress.instance.prolog.prolog0_1)
        {
            SceneManager.LoadScene("0-2_엘레베이터_앞");
        }

        if(GameProgress.instance.prolog.prolog0_3)
        {
            SceneManager.LoadScene("0-4_지하3층_도서관");
        }
    }
}
