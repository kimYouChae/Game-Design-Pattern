### 유저 인터페이스 🔜 MVC 패턴

- 목차
  - [MVC](#MVC-(-모델-뷰-컨트롤러-))
  - [MVC패턴과 팝업 시스템](#MVC-패턴과-Popup-시스템)

<hr>

# ✨MVC ( 모델 뷰 컨트롤러 )

⏩게임에서 화면과 게임로직, 데이터를 분리해서 서로 독립적으로 관리하는 디자인패턴

| Model | View | Controller |
| :-: | :-: | :-: |
| 데이터를 저장하는 컨테이너 | 인터페이스에 관해 담아두는 곳 | 게임데이터를 바탕으로 인터페이스에 보여주는 로직을 작성하는곳 |

<br>

<img width="442" height="321" alt="Image" src="https://github.com/user-attachments/assets/e9998747-c74d-4bdc-80be-4691360b20fa" />

<br>

_출처 : Unity 레벨업 유어 코드_

<br>

<details>
  <summary> MVC Model </summary>
    
``` c#
public class MVCModel 
{
    public Player1 player;

    public MVCModel(Player1 pr)
    {
        this.player = pr;
    }

    public void NickName(string n) 
    {
        player.UpdateNickName(n);
    }
}
```
</details>

``` c#
- 현재 플레이어의 데이터를 담아두는 역할로 사용하고 있음.
- 문제는 Model에서 플레이어를 참조하는 방식이 맞는지 의문이 듬.
- 현재는 Model이 가볍지만, 복잡해질 경우 해당 방식은 더 고민이 필요할듯
```

<br>

<details>
  <summary> MVC View </summary>
    
``` c#
public class MVCView : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button enterButton;

    public TextMeshProUGUI infoText;

    private Action<string> enterNickNameAction;

    public void RegisterCreatePlayer(Action<string> action) 
    {
        enterNickNameAction += action;
    }

    public void Start()
    {
        enterButton.onClick.AddListener(() => enterNickNameAction?.Invoke( inputField.text ));
    }

    public void UpdatePlayerInfo(string str) 
    {
        infoText.text = str;
    }
}
```
</details>

``` c#
- UI 컴포넌트에 관한 정보를 담고있음
- Button등에 연결할 동작은 `Action` 을 통해서 연결해줌
- UI 업데이트 로직만 작성, 실행은 Controller에서 실행
```

<br>

<details>
  <summary> MVC Controller </summary>

``` c#
public class MVCController 
{
    private MVCModel mvcModel;
    private MVCView mvcView;

    public MVCController(MVCModel model, MVCView view) 
    {
        this.mvcModel = model;
        this.mvcView = view;

        mvcView.RegisterCreatePlayer(UpdateUserInfo);
    }

    public void UpdateUserInfo(string name) 
    {
        mvcModel.NickName(name);

        Debug.Log("생성한 플레이어의 이름은" + mvcModel.player.NickName);

        // UI 업데이트
        mvcView.UpdatePlayerInfo(mvcModel.player.PlayerInfo());
    }
}
```
</details>

``` c#
- model과 view의 로직을 처리해주는 컨트롤러
- 생성자 실행과 동시에 View의 액션에 동작을 추가해줌
```

<br>
<hr>
    
# ✨MVC 패턴과 Popup 시스템

- Popup 시스템에 관한 자세한 내용은 아래 블로그를 참고
  - [https://youcheachae.tistory.com/69](https://youcheachae.tistory.com/63)
 
- 데이터와 UI가 명확히 분리되는 인벤토리를 예시로 들었음
  
<details>
  <summary> Inventory Model </summary>

``` c#
public class InventoryModel
{
    // 인벤토리 최대 슬롯 갯수
    public int maxSlot = 5;
    
    // 인벤토리 내 아이템 리스트
    public List<Item> items = new List<Item>();

    // 인덱스에 해당하는 아이템
    public Item IndexItem(int index) => items[index];
}
```
</details>

<details>
  <summary> Inventory View </summary>
    
``` c#
public class InventoryView : MonoBehaviour
{
    [SerializeField] Image[] itemIconSlot;
    [SerializeField] TextMeshProUGUI[] itemNameText;

    [SerializeField] Button itemAddButton;
    [SerializeField] Button itemDeleteButton;

    private Action itemAddAction;
    private Action itemDeleteAction;

    private void Awake()
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

    public void UpdateItemSlot(int idx, string name, Sprite icon)
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
```
</details>
    
<details>
  <summary> Inventory Controller </summary>
    
``` c#
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

    public void UpdateInventory() 
    {
        // UI 업데이트 
        for (int i = 0; i < inventoryModel.items.Count; i++)
        {
            Item curritem = inventoryModel.IndexItem(i);
            inventoryView.UpdateItemSlot(i, curritem.ItemName, curritem.IconSprite);
        }
    }
}
```
</details>

<br>

### 🔍 팝업 내부에서 MVC를 초기화

- 기존에는 LobbyManager같은 외부 매니져에서 MVC를 초기화 했음 (LobbyUIManager 참고 )
``` c#
mvcModel = new MVCModel(player);
mvcView = GetComponent<MVCView>();
mvcController = new MVCController(mvcModel, mvcView);
```

→ 하지만 Popup의 경우에는 Model, View, Controller가 팝업에 연관된 데이터흐름이기 때문에 <br>
팝업 내부에서 MVC를 구성하는것이 더 적합하다고 판단

<br>

- 이를 위해 UIPopUp 클래스의 Initpopup() 메서드를 override 하여 초기 1회 MVC 를 초기화 하게 만들었음
``` c#
protected override void Initpopup() 
{
    InventoryView view = GetComponent<InventoryView>();
    InventoryModel model = new InventoryModel();
    inventoryController = new InventoryController(model, view);
}
```
