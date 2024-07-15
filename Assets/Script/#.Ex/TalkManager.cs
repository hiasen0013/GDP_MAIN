using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(100, new string[]
        {
            "P:평범한 책상이다",
        });

        talkData.Add(200, new string[]
        {
            "P:평범한 침대다",
        });

        // Talk Data
        talkData.Add(1000, new string[] // NPC_A
        {
            "P:",
            "P:누나다! :5",
            "N:해리! 일찍 일어났네~ 잠은 잘 잤어? 오늘 일어났을 때 어디 불편한 건 없었고? :1",
            "P:음~ 딱히? 오늘은 뭐 해요? :4",
            "N:음… 어디 보자. :0",
            "N:오늘은 딱히 일정이 없어. 그냥 오후 5시쯤 진료한번 받고 끝날 거야. :2",
            "P:와~ 진짜여? 그러면~ 오늘 좀 이따 나랑 같이 놀면 안 돼요? :5",
            "N:음… 해리야 그게… 오늘 내가 좀 바빠서 그건 좀 어려울 것 같네…:0",
            "N:미안해 나중에는 어때? :2",
            "P:… :6",
            "N:정말이야! 해리.:0",
            "N:어차피 이번주에 너 상담 일정 있으니까 상담 끝나고 같이 놀자 알았지? :1",
            "P:응! 약속! :4",
            "N:당연하지! :2"
        });

        talkData.Add(2000, new string[] //해리 독백
        {
            "P:",
            "P:으윽… 아침마다 오는 이 두통은 언제쯤 없어지는 거야 :5?",
            "P:그나저나 오늘도 그 예쁜 누나가 오겠지? 언제쯤 오려나… :5",
            "P:… …"
        });

        // Portrait Data
        portraitData.Add(1000 + 0, portraitArr[0]); // 2_1
        portraitData.Add(1000 + 1, portraitArr[1]); // 2_2
        portraitData.Add(1000 + 2, portraitArr[2]); // 2_3

        portraitData.Add(1000 + 3, portraitArr[3]); // 1_1
        portraitData.Add(1000 + 4, portraitArr[4]); // 1_2
        portraitData.Add(1000 + 5, portraitArr[5]); // 1_3
        portraitData.Add(1000 + 6, portraitArr[6]); // 1_4

        // portraitData.Add(10000 + 0, portraitArr[0]); // 1_1
        // portraitData.Add(10000 + 1, portraitArr[1]); // 1_2
        // portraitData.Add(10000 + 2, portraitArr[2]); // 1_3
    }

    public string GetTalk(int id, int talkIndex)
    {
        Debug.Log($"Requesting talk for id: {id} and talkIndex: {talkIndex}");

        if (talkData.ContainsKey(id))
        {
            if (talkIndex >= talkData[id].Length)
            {
                return null;
            }
            else
            {
                return talkData[id][talkIndex];
            }
        }
        else
        {
            Debug.LogError($"Talk data for id: {id} not found");
            return null;
        }
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        if (portraitData.ContainsKey(id + portraitIndex))
        {
            return portraitData[id + portraitIndex];
        }
        else
        {
            Debug.LogError($"Portrait data for id: {id + portraitIndex} not found");
            return null;
        }
    }
}