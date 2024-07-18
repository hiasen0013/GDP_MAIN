using UnityEngine;

public class RemoveOnCollision : MonoBehaviour
{
    // 충돌 감지 메소드
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 태그가 "Player"인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // 현재 오브젝트를 제거
            Destroy(gameObject);
        }
    }

    // 트리거 감지 메소드 (만약 오브젝트가 트리거일 경우 사용)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 오브젝트의 태그가 "Player"인 경우
        if (other.CompareTag("Player"))
        {
            // 현재 오브젝트를 제거
            Destroy(gameObject);
        }
    }
}
