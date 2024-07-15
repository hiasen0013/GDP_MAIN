using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.SceneManagement;
public class Dialoug_test : MonoBehaviour
{
    [SerializeField] private Speaker[] speakers; // 대화에 참여하는 캐릭터들의 UI 배열
    [SerializeField] private DialogDate[] dialogs; // 현재 분기의 대사 목록 배열
    [SerializeField]
    private bool isAutoStart = true; // 자동 시작 여부
    private bool isFirst = true; // 최초 1회만 호출하기 위한 변수
    private int currentDialogIndex = -1; // 현재 대사 순번
    private int currentSpeakerIndex = 0; // 현재 말을 하는 화자의 speakers 배열 순번

    private void Awake()
    {
        SetUp();
    }

    private void SetUp()
    {
        for(int i = 0; i < speakers.Length; ++i) // 모든 대화 관련 게임 오브젝트 비활성화
        {
            SetActiveObjects(speakers[i], false); // 캐릭터 이미지는 보이도록 설정
            speakers[i].portraitImage.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        if(isFirst == true) // 대사 분기가 시작될 때 1회만 호출
        {
            SetUp(); // 초기화 시키고 캐릭터 이미지는 활성화, 대사 관련 UI는 모두 비활성화
            if(isAutoStart)SetNextDialog(); //자동재생으로 설정되어 있으면 첫 번째 대사 재생
                isFirst = false;

            if(Input.GetKeyDown(KeyCode.Space)) // 대사가 남아 있는 경우 스페이스 바를 눌러서 다음 대사 진행
            {
                if(dialogs.Length > currentDialogIndex + 1)
                {
                    SetNextDialog();
                }
            }
            else // 대사가 없는 경우 모든 오브젝트를 비활성화 하고 true 반환
            {
                for(int i = 0; i < speakers.Length; ++i) // 현재 대화에 참여했던 모든 캐릭터, 대화 UI를 보이지 않게 비활성화
                {
                    SetActiveObjects(speakers[i], false); //SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
                    speakers[i].portraitImage.gameObject.SetActive(false);
                }

                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false); // 이전 대화 관련 오브젝트 비활성화
        currentDialogIndex ++; // 다음 대사 진행
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex; // 현재 대사 순번 설정
        SetActiveObjects(speakers[currentSpeakerIndex], true); // 현재 대사 관련 오브젝트 활성화
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name; // 현재 대사의 이름 텍스트 설정
        speakers[currentSpeakerIndex].text.text = dialogs[currentDialogIndex].dialogue; // 현재 대사의 대사 설정
    }

    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.textImage.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);
        speaker.text.gameObject.SetActive(visible);
        speaker.endArrow.SetActive(false);
    }
}

    [System.Serializable] //직렬화
    public struct Speaker
    {
        public Image portraitImage; //캐릭터 이미지
        public Image textImage; // 대화창 이미지
        public TextMeshProUGUI textName; // 현재 대사중인 캐릭터 이름
        public TextMeshProUGUI text; // 현재 대사 출력
        public GameObject endArrow; // 대사 완료 커서
    }

    [System.Serializable]
    public struct DialogDate
    {
        public int speakerIndex; // 이름과 대사를 출력할 현재 스크립트의 speakers 배열 순번
        public string name; // 캐릭터 이름
        [TextArea(3, 5)]
        public string dialogue;
    }

