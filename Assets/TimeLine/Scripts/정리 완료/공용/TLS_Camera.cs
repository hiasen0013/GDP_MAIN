using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS_Camera : MonoBehaviour
{
    [SerializeField] private int index;

    public void TLS_5_Camera_Move()
    {
        index++;
        switch(index)
        {
            case 1:
                this.gameObject.transform.localPosition = new Vector3 (47.3f, 13.1f , -10);
                break;
            case 2:
                this.gameObject.transform.localPosition = new Vector3 (90.01f,0.41f,-10);
                GameObject player = GameObject.Find("해리");
                this.gameObject.transform.SetParent(player.transform);
                break;
        }
    }

    public void TLS_2_1_Camera_Move()
    {
        index++;
        switch(index)
        {
            case 1: 
                Debug.Log("이동함");
                this.gameObject.transform.localPosition = new Vector3(80.08f,-9.34f, -10); //8008
                break;
            
            case 2:
                Debug.Log("이동함2");
                this.gameObject.transform.localPosition = new Vector3(104.65f, -9.32f, -10);
                break;
        }
    }
}
