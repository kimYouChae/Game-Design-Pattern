using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
