using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class 임시타임라인코드 : MonoBehaviour
{
    public GameObject test1;
    public GameObject test2;

    private void OnEnable()
    {
        if(SystemMessage.instance.YorN == true)
        {
            test1.SetActive(true);
            test2.SetActive(false);
            
            if(test1.activeSelf)
            {
                TLS_Manager.instance.isDialog = true;
            }
        }
            else if(SystemMessage.instance.YorN == false)
            {
                test2.SetActive(true);
                test1.SetActive(false);
                
                if(test2.activeSelf)
                {
                    TLS_Manager.instance.isDialog = true;
                }
        }
    }
}