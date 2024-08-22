using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private FadeEffect fadeEffect;
    private PlayerManager playerManager;

    protected virtual void Start()
    {
        // FadeEffect 컴포넌트를 찾아 저장합니다.
        fadeEffect = FindObjectOfType<FadeEffect>();

        // PlayerManager 컴포넌트를 찾아 저장합니다.
        playerManager = FindObjectOfType<PlayerManager>();

        foreach (Transform child in transform)
        {
            ChildTrigger childTrigger = child.gameObject.AddComponent<ChildTrigger>();
            childTrigger.Setup(this, child.GetSiblingIndex());
        }
    }

    public virtual void OnChildTriggerEnter(Collider2D other, int childId)
    {
        Transform currentChildTransform = transform.GetChild(childId);
        Debug.Log($"{childId} 자식 오브젝트에서 {other.gameObject.name}이(가) 트리거에 들어왔습니다.");
        Debug.Log($"자식 오브젝트의 위치: {currentChildTransform.position}");

        // 트리거 발생 시 페이드 효과를 중단하고 다시 시작
        if (fadeEffect != null)
        {
            fadeEffect.StopAllCoroutines(); // 현재 진행 중인 페이드 효과를 중단

            // 페이드 효과가 시작될 때 PlayerManager의 애니메이션과 MoveCoroutine을 중단
            if (playerManager != null)
            {
                playerManager.SetFadingState(true);
            }

            fadeEffect.Onfade(FadeState.FadeIn); // 페이드 효과를 처음부터 다시 시작

            // 페이드 효과가 일정 시간 후에 완료될 것으로 가정하고 PlayerManager를 활성화
            Invoke(nameof(ReactivatePlayerManager), 1.0f); // 1초 후에 활성화 (시간은 필요에 따라 조정)
        }
        else
        {
            Debug.LogWarning("FadeEffect 컴포넌트를 찾을 수 없습니다.");
        }
    }

    private void ReactivatePlayerManager()
    {
        if (playerManager != null)
        {
            playerManager.SetFadingState(false); // 페이드 효과가 끝난 후 MoveCoroutine과 애니메이션을 재개
        }
    }
}

public class ChildTrigger : MonoBehaviour
{
    private MoveTrigger moveTrigger;
    [SerializeField] private int childId;

    public void Setup(MoveTrigger moveTrigger, int childId)
    {
        this.moveTrigger = moveTrigger;
        this.childId = childId;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        moveTrigger?.OnChildTriggerEnter(other, childId);
    }
}
