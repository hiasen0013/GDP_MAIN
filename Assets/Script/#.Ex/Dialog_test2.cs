using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog_test2 : MonoBehaviour
{
    [SerializeField] private Dialoug_test dialoug_Test;
    //[SerializeField] private Dialoug_test dialoug_Test2;

    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>dialoug_Test.UpdateDialog());
       // yield return new WaitUntil(()=>dialoug_Test2.UpdateDialog());

        //UnityEditor.EditorApplication.ExitPlaymode();
    }
    
}
