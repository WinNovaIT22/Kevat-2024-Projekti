using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeCoin : MonoBehaviour
{
    public int value;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            Destroy(this.gameObject);
            TextManager.instance.IncreaseCoins(value);
            PlayerPrefs.SetInt("Kerta", 1);
        }
    }
}

