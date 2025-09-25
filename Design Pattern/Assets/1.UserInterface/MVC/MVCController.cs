using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Debug.Log("������ �÷��̾��� �̸���" + mvcModel.player.NickName);

        // UI ������Ʈ
        mvcView.UpdatePlayerInfo(mvcModel.player.PlayerInfo());
    }
}
