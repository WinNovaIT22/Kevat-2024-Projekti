using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] public GameObject[] shadowObjects;

    private SpriteRenderer[] spriteRenderers; // Muuttuja, joka s‰ilytt‰‰ SpriteRendererit

    private float[] spriteWidth;
    private float[] spriteHeight;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = new SpriteRenderer[shadowObjects.Length]; // Alusta spriteRenderers-taulukko

        for (int i = 0; i < shadowObjects.Length; i++)
        {
            spriteRenderers[i] = shadowObjects[i].GetComponent<SpriteRenderer>(); // Hae SpriteRenderer kullekin peliobjektille
            spriteWidth[i] = spriteRenderers[i].sprite.bounds.size.x * shadowObjects[i].transform.lossyScale.x; // K‰yt‰ GetComponent<SpriteRenderer>() sen sijaan, ett‰ yrit‰t k‰ytt‰‰ shadowObjects[i].spriteRenderer
            spriteHeight[i] = spriteRenderers[i].sprite.bounds.size.y * shadowObjects[i].transform.lossyScale.y; // Sama t‰‰ll‰
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lightPosition = transform.position;

        for (int j = 0; j < shadowObjects.Length; j++)
        {
            Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y, 0f);
            Vector3 leftUpEdge = currentPosition - new Vector3(spriteWidth[j] / 2, -spriteHeight[j] / 2, 0f);
            Vector3 rightUpEdge = currentPosition + new Vector3(spriteWidth[j] / 2, spriteHeight[j] / 2, 0f);
            Vector3 leftDownEdge = currentPosition - new Vector3(spriteWidth[j] / 2, spriteHeight[j] / 2, 0f);
            Vector3 rightDownEdge = currentPosition + new Vector3(spriteWidth[j] / 2, -spriteHeight[j] / 2, 0f);

            Debug.DrawLine(leftUpEdge, lightPosition, Color.red);
            Debug.DrawLine(rightUpEdge, lightPosition, Color.red);
            Debug.DrawLine(leftDownEdge, lightPosition, Color.red);
            Debug.DrawLine(rightDownEdge, lightPosition, Color.red);
        }

    }
}
