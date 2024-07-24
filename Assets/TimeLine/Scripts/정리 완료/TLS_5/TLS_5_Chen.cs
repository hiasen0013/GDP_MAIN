using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_5_Chen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(this);
    }
}
