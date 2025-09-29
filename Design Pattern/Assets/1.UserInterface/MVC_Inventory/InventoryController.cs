using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryController 
{
    private InventoryModel inventoryModel;
    private InventoryView inventoryView;

    public InventoryController(InventoryModel inventoryModel, InventoryView inventoryPopup)
    {
        this.inventoryModel = inventoryModel;
        this.inventoryView = inventoryPopup;

        inventoryPopup.RegisterItemAdd(AddItem);
        inventoryPopup.RegisterItemDelete(DeleteItem);
    }

    // 아이템 추가 로직
    private void AddItem() 
    {
        Item randItem = MVC_ItemManager.instance.GetRandomItem();

        // model 에 아이템 추가
        // max를 넘지 않았으면 
        if (inventoryModel.items.Count < inventoryModel.maxSlot)
        { 
            inventoryModel.items.Add(randItem);
        }

        // 인벤토리 업데이트
        UpdateInventory();
    }

    // 아이템 삭제 로직
    private void DeleteItem() 
    {
        // 현재 마지막 아이템 삭제
        inventoryModel.items.RemoveAt( inventoryModel.items.Count - 1);

        // 인벤토리 업데이트
        inventoryView.ResetItemSlot();
        UpdateInventory();
    }

    private void UpdateInventory() 
    {
        // UI 업데이트 
        for (int i = 0; i < inventoryModel.items.Count; i++)
        {
            Item curritem = inventoryModel.IndexItem(i);
            inventoryView.UpdateItemSlot(i, curritem.ItemName, curritem.IconSprite);
        }
    }
}
