using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup  : UIPopUP
{
    // inventory 팝업의 MVC를 여기서 관리
    protected override void Initpopup() 
    {
        // view
        InventoryView view = GetComponent<InventoryView>();

        // model
        InventoryModel model = new InventoryModel();

        // Controller
        InventoryController inventoryController = new InventoryController(model, view);
    }
}
