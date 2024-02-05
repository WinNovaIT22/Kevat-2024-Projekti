using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeCoin : MonoBehaviour
{
    public int coins = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Coins", coins);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(coins);
        PlayerPrefs.SetInt("Coins", coins);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            coins += 1;
            Destroy(this.gameObject);
        }
    }
}

