using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public Upgrade assignedUpgrade;

    public Image icon;

    public Image buttonBacker;

    public Color canBuy;
    public Color cannotBuy;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;

    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(delegate { Buy(); });
    }

    private void Start()
    {
        nameText.text = assignedUpgrade.upgradeName;
        costText.text = assignedUpgrade.upgradeCost.ToString() + "g";
    }

    void Update()
    {
        if (assignedUpgrade.upgradeCost <= GameManager.MANAGER.coins)
        {
            buttonBacker.color = canBuy;
        }
        else
        {
            buttonBacker.color = cannotBuy;
        }
    }

    void Buy()
    {
        if (assignedUpgrade.upgradeCost <= GameManager.MANAGER.coins)
        {
            GameManager.MANAGER.coins -= assignedUpgrade.upgradeCost;

            GameManager.MANAGER.tierManager.tiers[assignedUpgrade.tierToUpgrade].upgradeLevel += assignedUpgrade.upgradeAmount;

            assignedUpgrade.purchased = true;

            gameObject.SetActive(false);

        }
    }
}
