using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTirgger : MonoBehaviour
{
    //상담실 counseling room[cs] / 복도 corridor[cd]
    private void Start()
    {
        // 모든 자식 오브젝트의 ChildColliderHandler를 찾습니다.
        MoveTriggerColliderHandler[] childColliders = GetComponentsInChildren<MoveTriggerColliderHandler>();
        foreach (MoveTriggerColliderHandler childCollider in childColliders)
        {
            // 자식 오브젝트의 OnTriggerEntered 이벤트에 OnChildTriggerEnter 메서드를 등록합니다.
            childCollider.OnTriggerEntered.AddListener(OnChildTriggerEnter);
        }
    }

    // 자식 오브젝트에서 호출할 메서드
    private void OnChildTriggerEnter(Collider other)
    {
        Debug.Log("1");
    }
}
