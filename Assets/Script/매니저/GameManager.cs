using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;

    public Image portraitImg;
    public TypeEffect talk;

    public GameObject talkPanel;
    public GameObject scanObject;

    public bool isAction;
    public int talkIndex;

    void Start()
    {
        talkPanel.SetActive(false);
    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();

        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        int talkId = id + questTalkIndex;

        Debug.Log($"Talking with id: {id}, questTalkIndex: {questTalkIndex}, talkId: {talkId}");

        string talkData = talkManager.GetTalk(talkId, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;

            print(questManager.CheckQuest(id));

            return;
        }

        string[] talkParts = talkData.Split(':');
        if (talkParts.Length < 2)
        {
            Debug.LogError("Invalid talk data format.");
            return;
        }

        string speaker = talkParts[0];
        string text = talkParts[1];

        talk.SetMsg(text);

        if (isNpc)
        {
            if (talkParts.Length > 2 && int.TryParse(talkParts[2], out int portraitIndex))
            {
                portraitImg.sprite = talkManager.GetPortrait(id, portraitIndex);
                portraitImg.color = new Color(1, 1, 1, 1);
            }
            else
            {
                Debug.LogError("Failed to parse portrait index.");
                portraitImg.color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }
}