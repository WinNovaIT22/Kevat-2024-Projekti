using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherCoins : MonoBehaviour
{
    public int gatheredCoins = 0;
    public int coins = 0;
    [SerializeField] GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Kerta") == 1)
        {
            gatheredCoins++;
            PlayerPrefs.SetInt("Kerta", 0);
        }

        if (gatheredCoins >= coins)
        {
            goal.SetActive(true);  
        }
    }
}
