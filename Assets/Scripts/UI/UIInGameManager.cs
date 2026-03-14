using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Singleton;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public void UpdateTextCoins(string s)
    {
        uiTextCoins.text = s;
    }
}
