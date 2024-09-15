using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLS2_HarryMove : MonoBehaviour
{
    public GameObject movePos_A;
    private bool scene2_HarryMove = false;

    [SerializeField] float speed;

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 movePos = movePos_A.transform.position;
        if(scene2_HarryMove == true)
        {
            transform.position = Vector3.MoveTowards(currentPosition, movePos, speed*Time.deltaTime);
            TLS_Manager.instance.isDialog = true;
        }
    }

    public void Scene2_HarryMovePose_A()
    {
        scene2_HarryMove = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("movePosA"))
        {
            scene2_HarryMove = false;
            TLS_Manager.instance.isDialog = false;
        }
    }
}