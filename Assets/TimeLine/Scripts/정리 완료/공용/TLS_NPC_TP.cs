using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_NPC_TP : MonoBehaviour
{
    public void NPC_TP()
    {
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.position.x, 0.2f, 0f);
    }
}
