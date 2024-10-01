using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InteractWithNote : MonoBehaviour
{
    public float interactionDistance = 2f; // 상호작용 거리
    public TextMeshProUGUI interactText; // 상호작용 문구를 표시할 TMPro 텍스트
    public float fadeSpeed = 2f; // 페이드 인/아웃 속도
    public GameObject uiPanel; // F 키로 토글할 UI 패널
    public List<Image> imageList; // UI 패널 안의 이미지들을 저장할 리스트

    private float currentAlpha = 0f;
    private bool isUIPanelActive = false; // UI 패널 활성화 상태
    private int currentImageIndex = 0; // 현재 보여지는 이미지의 인덱스

    private bool isPaused;

    void Start()
    {
        isPaused = false;
        if (interactText != null)
        {
            interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // note 태그를 가진 모든 오브젝트 찾기
        GameObject[] notes = GameObject.FindGameObjectsWithTag("note");

        foreach (GameObject note in notes)
        {
            // 플레이어와 note 오브젝트 사이의 거리 계산
            float distance = Vector2.Distance(transform.position, note.transform.position);

            // 상호작용 거리 이내에 있을 때
            if (distance <= interactionDistance)
            {
                // Check if interactText is assigned
                if (interactText != null)
                {
                    // 텍스트를 서서히 나타나게 함
                    currentAlpha = Mathf.Lerp(currentAlpha, 1f, fadeSpeed * Time.deltaTime);
                    interactText.color = new Color(interactText.color.r, interactText.color.g, interactText.color.b, currentAlpha);
                    interactText.gameObject.SetActive(true);
                }

                // F 키를 누르면 UI 패널 토글
                if (Input.GetKeyDown(KeyCode.X))
                {
                    ToggleUIPanel();
                }

                // Space 키를 누르면 다음 이미지로 이동
                if (isUIPanelActive && Input.GetButtonDown("Jump"))
                {
                    ChangeImage();
                }

                return;
            }
        }

        // 상호작용 거리 밖에 있을 때
        FadeOutInteractText();
    }

    private void ToggleUIPanel()
    {
        isUIPanelActive = !isUIPanelActive;
        uiPanel.SetActive(isUIPanelActive);

        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    private void ChangeImage()
    {
        currentImageIndex++;
        if (currentImageIndex >= imageList.Count)
        {
            currentImageIndex = 0; // 마지막 이미지면 처음으로 돌아감
        }

        // 모든 이미지를 비활성화하고 현재 이미지만 활성화
        foreach (Image image in imageList)
        {
            image.gameObject.SetActive(false);
        }
        imageList[currentImageIndex].gameObject.SetActive(true);
    }

    private void FadeOutInteractText()
    {
        if (interactText != null)
        {
            // 텍스트를 서서히 사라지게 함
            currentAlpha = Mathf.Lerp(currentAlpha, 0f, fadeSpeed * Time.deltaTime);
            interactText.color = new Color(interactText.color.r, interactText.color.g, interactText.color.b, currentAlpha);
            // 완전히 사라지면 오브젝트 비활성화
            if (currentAlpha <= 0f)
            {
                interactText.gameObject.SetActive(false);
            }
        }
    }
}
