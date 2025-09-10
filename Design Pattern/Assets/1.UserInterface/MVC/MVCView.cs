using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MVCView : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI nameText;

    public void UpdateHealth(int health) 
    {
        healthText.text = health.ToString();
    }

    public void UpdateName(string name) 
    {
        nameText.text = name;
    }
}
