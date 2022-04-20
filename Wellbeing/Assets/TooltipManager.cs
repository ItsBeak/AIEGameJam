using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager TM;

    public TextMeshProUGUI text;

    private void Awake()
    {
        if (TM != null && TM != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            TM = this;
        }
    }

    private void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void ShowTooltip(string message)
    {
        gameObject.SetActive(true);
        text.text = message;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        text.text = string.Empty;
    }

}
