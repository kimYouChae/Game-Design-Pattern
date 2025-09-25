using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

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
        sb.Append("�г���" + nickName + " / ");
        sb.Append("hp" + hp + " /" );
        sb.Append("���ݷ�" + attack + " / ");
        sb.Append("����" + defense + " / ");
        sb.Append("�ӵ�" + speed + " / ");

        return sb.ToString();
    }
}

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] Player1 player;

    [SerializeField] MVCController mvcController;
    [SerializeField] MVCModel mvcModel;
    [SerializeField] MVCView mvcView;

    private void Start()
    {
        // �ش� UI ���ϵ��� ��� Player1�� �����͸� �ٷ��
        player = new Player1("", 100,5,7,3);

        InitMVCExample();
    }

    private void InitMVCExample() 
    {
        mvcModel = new MVCModel(player);
        mvcView = GetComponent<MVCView>();
        mvcController = new MVCController(mvcModel, mvcView);
    }

}
