using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class TierUI : MonoBehaviour
{

    public Tier assignedTier;

    public Image icon;

    public Image buttonBacker;

    public Color canBuy;
    public Color cannotBuy;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI amountText;

    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener( delegate { Buy(); });
    }

    private void Start()
    {
        assignedTier.cost = assignedTier.baseCost;
        nameText.text = assignedTier.tierName;

    }

    void Update()
    {

        costText.text = assignedTier.cost.ToString() + "g";
        amountText.text = assignedTier.amountOwned.ToString();

        if (assignedTier.cost <= GameManager.MANAGER.coins)
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
        if (assignedTier.cost <= GameManager.MANAGER.coins)
        {
            GameManager.MANAGER.coins -= assignedTier.cost;

            assignedTier.amountOwned++;

            //assignedTier.cost = assignedTier.baseCost + (assignedTier.inflationAmount * assignedTier.amountOwned);

            assignedTier.cost = assignedTier.baseCost * Mathf.Pow(assignedTier.inflationAmount, assignedTier.amountOwned);



        }
    }
}
