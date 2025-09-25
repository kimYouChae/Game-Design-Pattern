using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
