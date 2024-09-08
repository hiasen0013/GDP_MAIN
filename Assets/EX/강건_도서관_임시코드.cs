using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 강건_도서관_임시코드 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && GameProgress.instance.tlProgress.prolog0_2)
        {
            SceneManager.LoadScene("0-4_지하3층_도서관");
        }
    }
}
