using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool move1 = false;

    Vector2 vektori;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToistaLiike());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ToistaLiike()
    {
        while (true)
        {
            // Liikuta palikkaa 10 yksikköä Y-akselilla
            this.gameObject.transform.Translate(0, 20 * Time.deltaTime, 0);

            // Odota 3 sekuntia
            yield return new WaitForSeconds(3);

            // Liikuta palikkaa takaisin -10 yksikköä Y-akselilla
            this.gameObject.transform.Translate(0, -20 * Time.deltaTime, 0);

            // Odota taas 3 sekuntia ennen seuraavaa toistoa
            yield return new WaitForSeconds(3);
        }
    }
}
