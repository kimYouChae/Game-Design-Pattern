using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup : UIPopUP
{
    [SerializeField] Image[] itemIconSlot;
    [SerializeField] TextMeshProUGUI[] itemNameText;

    [SerializeField] Button itemAddButton;
    [SerializeField] Button itemDeleteButton;

    private Action itemAddAction;
    private Action itemDeleteAction;

    protected override void Initpopup()
    {
        itemAddButton.onClick.AddListener(() => itemAddAction?.Invoke());
        itemDeleteButton.onClick.AddListener(() => itemDeleteAction?.Invoke());
    }

    public void RegisterItemAdd(Action addAction) 
    {
        itemAddAction += addAction;
    }

    public void RegisterItemDelete(Action deleteAction)
    {
        itemDeleteAction += deleteAction;
    }

    public void UpdateItemSlot( int idx ,string name, Sprite icon) 
    {
        itemIconSlot[idx].sprite = icon;
        itemNameText[idx].text = name;
    }

    public void ResetItemSlot() 
    {
        for (int i = 0; i < itemIconSlot.Length; i++) 
        {
            itemIconSlot[i].sprite = null;
            itemNameText[i].text = string.Empty;
        }
    }
}
