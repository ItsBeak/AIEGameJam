using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager MANAGER;

    public TierManager tierManager;
    public UpgradeManager upgradeManager;

    public float coins;
    public TextMeshProUGUI coinReadout;

    void Awake()
    {
        if (MANAGER != null && MANAGER != this)
        {
            Destroy(this);
        }
        else
        {
            MANAGER = this;
        }
    }

    void Update()
    {
        coinReadout.text = "Coins: " + Mathf.Round(coins * 100) / 100;
    }

    public void ThrowCoin()
    {
        coins++;
    }

    public void GenerateCoin(float modifier)
    {
        coins += modifier;
    }

}
