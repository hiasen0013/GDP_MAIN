using UnityEngine;

public class ScannableObject : MonoBehaviour
{
    public Dialog[] dialogs; // 배열로 변경

    // 구체의 크기를 조절할 수 있는 public 변수 선언
    public float sphereRadius = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // 구체의 크기를 sphereRadius 변수로 대체
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
}
