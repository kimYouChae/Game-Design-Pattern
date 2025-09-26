using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    // 인벤토리 최대 슬롯 갯수
    public int maxSlot = 5;
    
    // 인벤토리 내 아이템 리스트
    public List<Item> items = new List<Item>();

    // 인덱스에 해당하는 아이템
    public Item IndexItem(int index) => items[index];
}
