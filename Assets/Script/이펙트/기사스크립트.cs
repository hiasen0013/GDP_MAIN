using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class 기사스크립트 : MonoBehaviour
{
    // 대화 내용을 담는 배열
    private string[] dialogues;

    // 현재 진행 중인 대화 문장 인덱스
    private int currentLine = 0;

    // 대화 출력 텍스트 UI (TextMeshPro Text)
    public TMP_Text dialogueText;

    // 타이핑 효과 속도 (초당 출력 글자 수)
    public float typingSpeed = 100f;

    // 대화가 진행 중인지 여부
    private bool isTalking = false;
    private bool isTyping = false; // 현재 타이핑 진행 중인지 여부를 판단하는 변수

    void Start()
    {
        // 대화 내용 설정
        dialogues = new string[] {
            "",
            "20XX년 5월 27일 미국 캘리포니아 주의 한 대교에서 덤프트럭을 몰다 청년 H씨를 숨지게 한 50대 트럭 기사 E씨를 교통사고 처리특례법상 치사 혐의로 기사 했다고 밝혔다.",
            "경찰에 따르면 E씨는 지난해 5월 27일 오후 3시 58분쯤 한 대교에서 승용차를 타고 가던 H씨를 치어 숨지게 한 혐의를 받는다.",
            "H씨는 당시 승용차를 탄 채 운전 하던 도중 과속으로 달리던 E씨의 덤프트럭과 앞차의 이중 사고로 압사로 숨졌다.",
            "다만 E씨는 과속이 아닌 브레이크 고장으로 인한 사고였음을 알리며 고의가 아니라는 의견을......",
            "......",
            "......",
            "머리가 아프다. 얼마나 잔 거지?",
            "근데도 계속 졸음이..."
        };

        // 처음 대화 시작
        StartDialogue();
    }

    void Update()
    {
        // 스페이스바 입력 감지 (현재 타이핑 진행 중이 아니고 대화가 진행 중일 때만 반응)
        if (Input.GetKeyDown(KeyCode.Space) && !isTyping && isTalking)
        {
            // 다음 대화 문장 출력
            NextDialogue();
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        currentLine = 0;

        // 첫 번째 문장 출력
        StartCoroutine(TypeEffect(dialogues[currentLine]));
    }

    void NextDialogue()
    {
        // 마지막 문장까지 도달했으면 종료
        if (currentLine >= dialogues.Length)
        {
            EndDialogue();
            return;
        }

        // 이전 문장 사라지도록 설정
        dialogueText.text = "";

        // 다음 문장 출력
        StartCoroutine(TypeEffect(dialogues[currentLine]));

        // 다음 문장으로 이동
        currentLine++;
    }

    IEnumerator TypeEffect(string text)
    {
        isTyping = true; // 타이핑 시작

        // 한 글자씩 빠르게 출력
        foreach (char c in text)
        {
            dialogueText.SetText(dialogueText.text + c);
            yield return new WaitForSeconds(1f / typingSpeed);
        }

        isTyping = false; // 타이핑 종료
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueText.SetText("");

        // 씬 전환을 위한 메서드 호출
        StartCoroutine(LoadSceneAfterDelay("1_RoomCutScene", 1f)); // 1초 후에 "1.Room" 씬으로 전환
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
