using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    public int itemCount;
    public Sprite itemIcon;

    public ItemType itemType;

    public enum ItemType
    {
        Use, // 소모품
        Equip, // 장비 아이템
        Quest, // 퀘스트 아이템
        ETC // 기타 아이템
    }

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;

        itemIcon = Resources.Load("HandOut/HandOut_Dot/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}