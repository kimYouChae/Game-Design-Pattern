using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] int itemIndex;     // 아이템번호
    [SerializeField] string itemName;    // 아이템 이름
    [SerializeField] Sprite iconSprite;

    public Item(int id, string na, Sprite sp) 
    {
        this.itemIndex = id;
        this.itemName = na;
        this.iconSprite = sp;
    }

    public string ItemName { get => itemName;  }
    public Sprite IconSprite { get => iconSprite; }
}

public class MVC_ItemManager : MonoBehaviour
{
    public static MVC_ItemManager instance;

    [SerializeField]
    Sprite[] itemSprite;
    [SerializeField]
    string[] itemName;

    [SerializeField]
    List<Item> items;

    private void Awake()
    {
        instance = this;

        items = new List<Item> ();

        for(int i = 0; i < 4; i++) 
        {
            items.Add(new Item(i, itemName[i], itemSprite[i]));
        }
        
    }

    public Item GetRandomItem() 
    {
        int rand = Random.Range(0, items.Count);

        return items[rand];
    }
}
