using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Singleton;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;
    public TextMeshProUGUI collectedCoins;
    public SOInt coins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        //collectedCoins.text = "x " + coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        //collectedCoins.text = "x " + coins.ToString();
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIInGameManager.Instance.UpdateTextCoins(coins.ToString());
    }
}
