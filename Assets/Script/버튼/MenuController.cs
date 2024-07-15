using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button newGameButton;
    public Button loadGameButton;
    public Button quitButton;
    public Image selectionIndicator; // ���� ��������Ʈ�� ǥ���� Image
    public Vector3 selectionIndicatorOffset; // ���� ��������Ʈ�� ��ġ ������

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
                colors.normalColor = Color.yellow; // ���õ� ��ư�� ���� ��������� ����
                buttons[i].transform.localScale = new Vector3(1.1f, 1.1f, 1); // ���õ� ��ư�� ũ�⸦ �ణ Ű��
                // ���� ��������Ʈ ��ġ�� ���õ� ��ư���� �̵� + ������ ����
                selectionIndicator.transform.position = buttons[i].transform.position + selectionIndicatorOffset;
                selectionIndicator.gameObject.SetActive(true);
            }
            else
            {
                colors.normalColor = Color.white; // ���õ��� ���� ��ư�� ���� ������� ����
                buttons[i].transform.localScale = new Vector3(1, 1, 1); // ���õ��� ���� ��ư�� ũ�⸦ �������
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
