using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup  : UIPopUP
{
    InventoryController inventoryController;

    // inventory 팝업의 MVC를 여기서 관리
    protected override void Initpopup() 
    {
        // view
        InventoryView view = GetComponent<InventoryView>();

        // model
        InventoryModel model = new InventoryModel();

        // Controller
         inventoryController = new InventoryController(model, view);
    }

    // 켜질 때 초기화
    // 1. controller의 초기화 메서드 실행
    // 2. UIPopUP 스크립트에서 메서드 override 하는 방식으로도 가능할 듯 
    public void InitInventory() 
    {
        inventoryController.UpdateInventory();
    }
}
