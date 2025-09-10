using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCController : MonoBehaviour
{
    private MVCPlayer mvcPlayer;
    private MVCView mvcView;

    private void Start()
    {
        mvcPlayer = new MVCPlayer(10, "Potato");
        mvcView = this.GetComponent<MVCView>();

        mvcView.UpdateHealth(mvcPlayer.Health);
        mvcView.UpdateName(mvcPlayer.Name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            mvcPlayer.Health += 10;
            mvcView.UpdateHealth(mvcPlayer.Health);
        }
    }
}
