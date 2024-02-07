using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI coinsText;

    public static TextManager instance;

    public int currentCoins = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Coins: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinsText.text = "Coins: " + currentCoins.ToString();
    }
}
