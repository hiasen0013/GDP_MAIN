using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private SpriteRenderer spr;
    private bool can_opneDoor;
    private void Start() 
    {
        can_opneDoor = false;
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("z");
            spr.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player"))
        {
            can_opneDoor = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            can_opneDoor = false;
        }
    }
}
