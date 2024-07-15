using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("첸과 대화하기", new int[] { 1000, 2000 }));

        questList.Add(20, new QuestData("연구실 살펴보기", new int[] { 1000, 2000 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }

        return questList[questId].questName;
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
}