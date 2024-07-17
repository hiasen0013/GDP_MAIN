using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    void Start()
    {
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
    }
}

public class ChildTrigger : MonoBehaviour
{
    private MoveTrigger moveTrigger;
    private int childId;


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