using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using TMPro;

public class TierUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

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

        costText.text = (Mathf.Round((float)assignedTier.cost * 100) / 100).ToString() + "g";
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ayy lmao");
        TooltipManager.TM.ShowTooltip(assignedTier.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.TM.HideTooltip();
        Debug.Log("ayy where you go");
    }
    
}
