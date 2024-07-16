using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveTriggerColliderHandler : MonoBehaviour
{
    public UnityEvent<Collider> OnTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTriggerEntered?.Invoke(other);
        }
    }
}
