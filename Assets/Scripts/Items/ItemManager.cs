using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{

    public static ItemManager Instance;
    public TextMeshProUGUI collectedCoins;
    public int coins;

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
        coins = 0;
        collectedCoins.text = "x " + coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        collectedCoins.text = "x " + coins.ToString();
    }
}
