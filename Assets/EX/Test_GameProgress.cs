using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_GameProgress : MonoBehaviour
{
    private Dictionary<bool, (string sceneName,System.Action setFalse)> sceneMapping;

    private void Start()
    {
        sceneMapping = new Dictionary<bool, (string, System.Action)>
        {
            {GameProgress.instance.prolog.prolog0_1,("0-2_엘레베이터_앞", () => GameProgress.instance.prolog.prolog0_1 = false)},
            {GameProgress.instance.prolog.prolog0_3, ("0-4_지하3층_도서관", () => GameProgress.instance.prolog.prolog0_3 = false)}
        };
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        foreach(var scene in sceneMapping)
        {
            if(scene.Key)
            {
                SceneManager.LoadScene(scene.Value.sceneName);
                scene.Value.setFalse();
                break;
            }
        }
    }
}
