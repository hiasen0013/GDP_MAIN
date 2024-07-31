using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private List<GameObject> speech_obj;
    private int index = 0;
    public void Speech_bubble_OnEnable()
    {
        StartCoroutine(Speech_obj_Active());
    }
    
    IEnumerator Speech_obj_Active()
    {
        TLS_Manager.instance.isDialog = true;
        speech_obj[index].SetActive(true);
        yield return new WaitForSeconds(2f);
        TLS_Manager.instance.isDialog = false;
        speech_obj[index].SetActive(false);
        index ++;
    }
}
