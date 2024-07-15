using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    int index;

    float interval;

    public GameObject EndCursor;

    string targetMsg;

    TextMeshProUGUI msgText;

    private void Awake()
    {
        msgText = GetComponent<TextMeshProUGUI>();
        if (msgText == null)
        {
            Debug.LogError("TextMeshProUGUI component is not attached to the GameObject.");
        }

        if (EndCursor == null)
        {
            Debug.LogError("EndCursor is not assigned.");
        }
    }

    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }

    void EffectStart()
    {
        if (msgText == null) return;

        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;

        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if (msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        EndCursor.SetActive(true);
    }
}




// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class TypeEffect : MonoBehaviour
// {
//     public int CharPerSeconds;
//     int index;

//     float interval;

//     public GameObject EndCursor;

//     string targetMsg;

//     TextMeshProUGUI msgText;

//     private void Awake()
//     {
//         msgText = GetComponent<TextMeshProUGUI>();
//         if (msgText == null)
//         {
//             Debug.LogError("TextMeshProUGUI component is not attached to the GameObject.");
//         }

//         if (EndCursor == null)
//         {
//             Debug.LogError("EndCursor is not assigned.");
//         }
//     }

//     public void SetMsg(string msg)
//     {
//         targetMsg = msg;
//         EffectStart();
//     }

//     void EffectStart()
//     {
//         if (msgText == null) return;

//         msgText.text = "";
//         index = 0;
//         EndCursor.SetActive(false);

//         interval = 1.0f / CharPerSeconds;

//         Invoke("Effecting", interval); // CharPerSeconds로 나누는 값이 실수여야 합니다.
//     }

//     void Effecting()
//     {
//         if (msgText.text == targetMsg)
//         {
//             EffectEnd();
//             return;
//         }

//         msgText.text += targetMsg[index];
//         index++;

//         Invoke("Effecting", interval); // CharPerSeconds로 나누는 값이 실수여야 합니다.
//     }

//     void EffectEnd()
//     {
//         EndCursor.SetActive(true);
//     }
// }
