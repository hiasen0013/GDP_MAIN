using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요한 네임스페이스

public class DynamicSortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int sortingOrderOffset = 1000; // 기본 오프셋 값
    public int sortingOrderMin = 0; // 최소 sortingOrder 값
    public string targetSceneName = "YourSceneName"; // 이 스크립트가 작동할 씬의 이름

    void Start()
    {
        // 이 오브젝트의 SpriteRenderer 컴포넌트를 가져옴
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 현재 활성화된 씬 이름 확인
        if (SceneManager.GetActiveScene().name == targetSceneName)
        {
            // y 좌표에 따라 sortingOrder를 계산
            int sortingOrder = Mathf.RoundToInt(-transform.position.y * 100) + sortingOrderOffset;

            // sortingOrder가 최소값보다 작아지지 않도록 보장
            spriteRenderer.sortingOrder = Mathf.Max(sortingOrder, sortingOrderMin);
        }
    }
}
