using UnityEngine;

public class NPCAgent : MonoBehaviour
{
    // 이동 속도
    public float moveSpeed = 2.0f;

    // 이동 경로 (Vector3 배열)
    public Vector3[] waypoints;

    // 현재 목표 지점 인덱스
    private int currentWaypoint = 0;

    void Start()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("NPC 에 이동 경로가 설정되지 않았습니다!");
            return;
        }
    }

    void Update()
    {
        // 현재 위치와 목표 지점 사이의 거리 계산
        Vector3 distance = waypoints[currentWaypoint] - transform.position;

        // 목표 지점에 도달했는지 확인
        if (distance.magnitude < 0.1f)
        {
            // 다음 목표 지점으로 이동
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            distance = waypoints[currentWaypoint] - transform.position;
        }

        // 이동 방향 설정
        Vector3 moveDirection = distance.normalized;

        // 이동 (moveSpeed 만큼 방향 벡터에 곱하여 속도 조절)
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
