using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    static public DatabaseManager instance;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;



    public List<Item> itemList = new List<Item>();

    void Start()
    {
        itemList.Add(new Item(10001, "노트", "?의 일기", Item.ItemType.Quest));
        itemList.Add(new Item(10002, "밧줄", "오래된 밧줄", Item.ItemType.ETC));
        itemList.Add(new Item(10003, "서류", "문서", Item.ItemType.ETC));
        itemList.Add(new Item(10004, "안정제", "실험체용", Item.ItemType.ETC));
        itemList.Add(new Item(10005, "열쇠", "?에 사용하는 열쇠", Item.ItemType.Use));
        itemList.Add(new Item(10006, "쥐인형", "오츠의 쥐인형", Item.ItemType.Quest));
        itemList.Add(new Item(10007, "쪽지", "첸이 안나에게 보내는 쪽지", Item.ItemType.ETC));
        itemList.Add(new Item(10008, "책", "도서관의 책", Item.ItemType.Quest));
        itemList.Add(new Item(10009, "칩", "?에서 분리된 칩", Item.ItemType.Use));
        itemList.Add(new Item(10010, "칼", "공격용 칼", Item.ItemType.Equip));
        itemList.Add(new Item(10011, "톱", "평범한 톱", Item.ItemType.Equip));
    }
}