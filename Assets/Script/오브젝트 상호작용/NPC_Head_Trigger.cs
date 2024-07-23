using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Head_Trigger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;

    private void OnTriggerEnter2D(Collider2D other) {
        spr.sortingOrder = 1;
        Debug.Log("들어옴");
    }

    private void OnTriggerExit2D(Collider2D other) {
        spr.sortingOrder = -1;
        Debug.Log("나감");
    }
}
