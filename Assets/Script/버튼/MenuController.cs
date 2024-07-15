using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button quitButton;
    public Image selectionIndicator; // 선택 스프라이트를 표시할 Image
    public Vector3 selectionIndicatorOffset; // 선택 스프라이트의 위치 오프셋

    private int selectedIndex = 0;
    private Button[] buttons;

    void Start()
    {
        buttons = new Button[] { newGameButton, loadGameButton, quitButton };
        UpdateButtonSelection();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = (selectedIndex + 1) % buttons.Length;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = (selectedIndex - 1 + buttons.Length) % buttons.Length;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    void UpdateButtonSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock colors = buttons[i].colors;
            if (i == selectedIndex)
            {
                colors.normalColor = Color.yellow; // 선택된 버튼의 색을 노란색으로 변경
                buttons[i].transform.localScale = new Vector3(1.1f, 1.1f, 1); // 선택된 버튼의 크기를 약간 키움
                // 선택 스프라이트 위치를 선택된 버튼으로 이동 + 오프셋 적용
                selectionIndicator.transform.position = buttons[i].transform.position + selectionIndicatorOffset;
                selectionIndicator.gameObject.SetActive(true);
            }
            else
            {
                colors.normalColor = Color.white; // 선택되지 않은 버튼의 색을 흰색으로 변경
                buttons[i].transform.localScale = new Vector3(1, 1, 1); // 선택되지 않은 버튼의 크기를 원래대로
            }
            buttons[i].colors = colors;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
