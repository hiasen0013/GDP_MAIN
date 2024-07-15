using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController_상호작용 : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayerMask;
    [SerializeField] private float scanDistance = 2f;
    [SerializeField] private Image dialogPortrait;
    [SerializeField] private Image dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI dialogNameText;

    [SerializeField]private SpriteRenderer spr;

    private ScannableObject currentObject;
    private Vector2 inputDirection = Vector2.zero;

    void Update()
    {
        HandleInput();
        ScanForObject();

        if (Input.GetButtonDown("Jump") && currentObject != null)
        {
            ShowDialog(currentObject.dialog);
        }
        if(CutSceneManager.instance.is_Second_CutScene)
        {
            spr.enabled = false;
        }
    }

    void HandleInput()
    {
        inputDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            inputDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputDirection = Vector2.right;
        }
    }

    void ScanForObject()
    {
        if (inputDirection != Vector2.zero)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, inputDirection, scanDistance, objectLayerMask);

            if (hit.collider != null)
            {
                currentObject = hit.collider.GetComponent<ScannableObject>();
            }
            else
            {
                currentObject = null;
            }

            Debug.DrawRay(transform.position, inputDirection * scanDistance, Color.red); // Ray를 시각화하여 확인
        }
    }

    void ShowDialog(Dialog dialog)
    {
        dialogBox.gameObject.SetActive(true);
        dialogPortrait.sprite = dialog.portrait;
        dialogText.text = dialog.dialog;
        dialogNameText.text = dialog.dialog_name;

        StartCoroutine(HideDialog());
    }

    System.Collections.IEnumerator HideDialog()
    {
        yield return new WaitForSeconds(5f); // 대사 표시 시간. 필요에 따라 조정 가능
        dialogBox.gameObject.SetActive(false);
    }
}
