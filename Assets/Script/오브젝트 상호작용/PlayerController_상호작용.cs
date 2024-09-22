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
    private int currentDialogIndex = 0;

    private bool isTyping = false; // 타이핑 중인지 여부
    private bool isTalking = false; // 대화가 진행 중인지 여부

    void Update()
    {
        HandleInput();
        ScanForObject();

        // 스페이스바 입력 처리
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 대화가 진행 중인 경우
            if (isTalking)
            {
                // 타이핑 중이면 다음 문장으로 넘기지 않음
                if (!isTyping)
                {
                    if (currentDialogIndex < currentObject.dialogs.Length - 1)
                    {
                        currentDialogIndex++;
                        ShowDialog(currentObject.dialogs[currentDialogIndex]);
                    }
                    else
                    {
                        EndDialog();
                    }
                }
            }
            // 대화 시작
            else if (currentObject != null)
            {
                currentDialogIndex = 0;
                StartDialog();
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

    // 대화 시작 메서드
    void StartDialog()
    {
        isTalking = true;
        dialogBox.gameObject.SetActive(true);
        ShowDialog(currentObject.dialogs[currentDialogIndex]);
    }

    // 대화 종료 메서드
    void EndDialog()
    {
        isTalking = false;
        dialogBox.gameObject.SetActive(false);
    }

    void ShowDialog(Dialog dialog)
    {
        dialogPortrait.sprite = dialog.portrait;
        dialogNameText.text = dialog.dialog_name;
        StartCoroutine(TypeEffect(dialog.dialog));
    }

    IEnumerator TypeEffect(string text)
    {
        isTyping = true; // 타이핑 중임을 표시
        dialogText.text = "";

        foreach (char c in text)
        {
            dialogText.SetText(dialogText.text + c);
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false; // 타이핑이 완료되었음을 표시
    }
}