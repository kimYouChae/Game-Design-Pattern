using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player1
{
    [SerializeField] private string nickName;     
    [SerializeField] private float hp;
    [SerializeField] private float attack;
    [SerializeField] private float defense;
    [SerializeField] private float speed;

    public string NickName => nickName;
    public float HP => hp;
    public float Attack => attack;
    public float Defense => defense;
    public float Speed => speed;

    public Player1(string nickName, float hp, float attack, float defense, float speed)
    {
        this.nickName = nickName;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
    }

    public void UpdateNickName(string str) 
    {
        nickName = str;
    }

    public string PlayerInfo() 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("닉네임" + nickName + " / ");
        sb.Append("hp" + hp + " /" );
        sb.Append("공격력" + attack + " / ");
        sb.Append("방어력" + defense + " / ");
        sb.Append("속도" + speed + " / ");

        return sb.ToString();
    }
}

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] Player1 player;

    // MVC 예시
    [SerializeField] MVCController mvcController;
    [SerializeField] MVCModel mvcModel;
    [SerializeField] MVCView mvcView;

    // MVC 팝업 예시
    [SerializeField] Button mvcPopupButton;

    private void Awake()
    {
        mvcPopupButton.onClick.AddListener(() => 
        {
            InventoryPopup popup = UIManager.Instance.GetPopUP<InventoryPopup>();
        });
    }

    private void Start()
    {
        // 해당 UI 패턴들은 모두 Player1의 데이터를 다룬다
        player = new Player1("", 100,5,7,3);

        InitMVCExample();        
    }

    private void InitMVCExample() 
    {
        // model에 플레이어를 넘겨준다 
        // 지금은 MVC가 가벼워서 괜찮지만, 참조를 깊게 하는것같아서 좀더 고민 해봐야할듯
        mvcModel = new MVCModel(player);
        mvcView = GetComponent<MVCView>();
        mvcController = new MVCController(mvcModel, mvcView);
    }

}
