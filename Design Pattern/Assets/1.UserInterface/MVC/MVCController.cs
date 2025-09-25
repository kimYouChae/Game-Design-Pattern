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

        Debug.Log("생성한 플레이어의 이름은" + mvcModel.player.NickName);

        // UI 업데이트
        mvcView.UpdatePlayerInfo(mvcModel.player.PlayerInfo());
    }
}
