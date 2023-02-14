using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager MANAGER;

    public GameObject myPrefab;

    public TierManager tierManager;
    public UpgradeManager upgradeManager;

    public double coins;
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
        coinReadout.text = "Coins: " + Mathf.Round((float)coins * 100) / 100;
    }

    public void ThrowCoin()
    {
        coins++;

        Instantiate(myPrefab, new Vector3(-2.3f, 15f, 7f), Quaternion.identity);
    }

    public void GenerateCoin(float modifier)
    {
        coins += modifier;
    }

}
