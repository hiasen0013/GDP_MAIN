using UnityEngine;
using UnityEngine.UI;

public class MoveTrigger : MonoBehaviour
{
    private FadeEffect fadeEffect;

    protected virtual void Start()
    {
        // FadeEffect 컴포넌트를 찾아 저장합니다.
        fadeEffect = FindObjectOfType<FadeEffect>();

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

        // 트리거 발생 시 화면이 밝아지도록 FadeEffect의 Onfade 메서드 호출
        if (fadeEffect != null)
        {
            fadeEffect.Onfade(FadeState.FadeIn);
        }
        else
        {
            Debug.LogWarning("FadeEffect 컴포넌트를 찾을 수 없습니다.");
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
