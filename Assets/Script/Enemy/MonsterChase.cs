using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public float moveSpeed = 3f;  // 몬스터의 이동 속도
    public Transform player;  // 플레이어를 참조할 변수
    public string playerTag = "Player";  // 플레이어 태그 (기본값은 "Player")

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag(playerTag).transform;
        }
    }

    private void Update()
    {
        ChasePlayer();
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Vector3 moveDirection;

            // X축과 Y축 중 더 큰 방향으로 몬스터를 움직임
            if (Mathf.Abs(directionToPlayer.x) > Mathf.Abs(directionToPlayer.y))
            {
                moveDirection = new Vector3(Mathf.Sign(directionToPlayer.x), 0f, 0f);  // X축으로 이동
            }
            else
            {
                moveDirection = new Vector3(0f, Mathf.Sign(directionToPlayer.y), 0f);  // Y축으로 이동
            }

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
