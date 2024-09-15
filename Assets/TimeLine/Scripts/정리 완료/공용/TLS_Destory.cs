using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Destory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
        }
    }
}