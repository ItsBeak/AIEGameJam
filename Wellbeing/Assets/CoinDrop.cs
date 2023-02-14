using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnCoin()
    {
        Instantiate(myPrefab, new Vector3(-2.3f, 15f, 7f), Quaternion.identity);
    }
}
