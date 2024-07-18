using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerController_상호작용 : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayerMask;
    [SerializeField] private float scanDistance = 2f;
    [SerializeField] private Image dialogPortrait;
    [SerializeField] private Image dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private TextMeshProUGUI dialogNameText;
    [SerializeField] private float typingSpeed = 100f;

    [SerializeField] private SpriteRenderer spr;

    private ScannableObject currentObject;
    private Vector2 inputDirection = Vector2.zero;

    void Update()
    {
        HandleInput();
        ScanForObject();

        if (Input.GetButtonDown("Jump"))
        {
            if (dialogBox.gameObject.activeSelf)
            {
                dialogBox.gameObject.SetActive(false);
            }
            else if (currentObject != null)
            {
                ShowDialog(currentObject.dialog);
            }
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
        dialogNameText.text = dialog.dialog_name;
        StartCoroutine(TypeEffect(dialog.dialog));
    }

    IEnumerator TypeEffect(string text)
    {
        dialogText.text = "";

        foreach (char c in text)
        {
            dialogText.SetText(dialogText.text + c);
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        StartCoroutine(HideDialog());
    }

    IEnumerator HideDialog()
    {
        yield return new WaitForSeconds(5f); // 대사 표시 시간. 필요에 따라 조정 가능
        dialogBox.gameObject.SetActive(false);
    }
}
