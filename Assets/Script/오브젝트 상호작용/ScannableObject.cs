using UnityEngine;

public class ScannableObject : MonoBehaviour
{
    public Dialog dialog;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
