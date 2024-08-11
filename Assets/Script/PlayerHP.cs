using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public int hp = 100; // 플레이어의 체력
    public GameObject enemyObject; // 인스펙터 창에서 할당할 적 오브젝트
    private bool isCollidingWithEnemy = false; // 적과 충돌 중인지 확인하기 위한 변수
    private bool isCollidingWithChip = false; // '화형' 태그를 가진 오브젝트와 충돌 중인지 확인하기 위한 변수

    void Start()
    {
        Debug.Log("Player HP: " + hp);
    }

    void Update()
    {
        if (isCollidingWithEnemy)
        {
            // 체력이 0 이하가 되면 플레이어 파괴 및 씬 변경
            if (hp <= 0)
            {
                Debug.Log("Player HP is zero or less. Destroying player and loading StartScene.");
                Destroy(gameObject);
                SceneManager.LoadScene("StartScene");
            }

            // KeyCode.A 버튼을 누르면 적 파괴
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (enemyObject != null)
                {
                    Debug.Log("KeyCode.A pressed. Destroying enemy.");
                    Destroy(enemyObject);
                    isCollidingWithEnemy = false; // 적이 파괴되었으므로 충돌 상태 해제
                }
            }
        }

        if (isCollidingWithChip && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("칩을 얻었다.");
        }
    }

    private IEnumerator DecreaseHP()
    {
        while (isCollidingWithEnemy)
        {
            hp -= 10;
            Debug.Log("Player HP: " + hp);
            yield return new WaitForSeconds(1f); // 1초마다 체력 감소
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 인스펙터 창에서 할당한 적 오브젝트와 충돌한 경우
        if (other.gameObject == enemyObject)
        {
            Debug.Log("Colliding with enemy.");
            isCollidingWithEnemy = true;

            // 체력 감소 코루틴 시작
            StartCoroutine(DecreaseHP());
        }

        // '화형' 태그를 가진 오브젝트와 충돌한 경우
        if (other.CompareTag("화형"))
        {
            Debug.Log("Colliding with '화형' object.");
            isCollidingWithChip = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 인스펙터 창에서 할당한 적 오브젝트와의 충돌이 끝난 경우
        if (other.gameObject == enemyObject)
        {
            Debug.Log("Stopped colliding with enemy.");
            isCollidingWithEnemy = false;

            // 체력 감소 중지
            StopCoroutine(DecreaseHP());
        }

        // '화형' 태그를 가진 오브젝트와의 충돌이 끝난 경우
        if (other.CompareTag("화형"))
        {
            Debug.Log("Stopped colliding with '화형' object.");
            isCollidingWithChip = false;
        }
    }
}
