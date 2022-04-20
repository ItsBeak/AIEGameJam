using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisualiser : MonoBehaviour
{
    public GameManager manager;
    public List<Visual> visuals;

    private void Start()
    {
        InvokeRepeating("CheckVisuals", 0.1f, 0.1f);
    }

    void CheckVisuals()
    {
        Debug.Log(manager.coins);

        foreach (Visual v in visuals)
        {
            if (manager.coins >= v.goldLevel)
            {
                v.target.SetActive(true);
            }
            else
            {
                v.target.SetActive(false);
            }
        }
    }

}

[System.Serializable]
public class Visual
{
    public double goldLevel;
    public GameObject target;
}
