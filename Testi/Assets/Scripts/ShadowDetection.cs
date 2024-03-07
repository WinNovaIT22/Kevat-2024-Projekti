using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowDetection : MonoBehaviour
{
    public GameObject light;
    private float spriteWidth;
    private float spriteHeight;

    bool isPlayerInsideAnyShadow = false; // Lippu kertoo, onko pelaaja miss‰‰n varjossa

    float extendDistance = 20f;
    float minY = -8f;

    void Start()
    {
        SpriteRenderer sRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x * transform.lossyScale.x;
        spriteHeight = sRenderer.sprite.bounds.size.y * transform.lossyScale.y;
    }

    void Update()
    {
        ShadowDetection[] shadowObjects = FindObjectsOfType<ShadowDetection>();

        // Resetoi lipun jokaisen framen alussa
        isPlayerInsideAnyShadow = false;

        foreach (ShadowDetection shadowObject in shadowObjects)
        {
            if (shadowObject != this)
            {
                if (shadowObject.IsPlayerInside())
                {
                    // Pelaaja on miss‰‰n varjossa
                    isPlayerInsideAnyShadow = true;
                    break; // Lopeta silmukka, koska tied‰mme, ett‰ pelaaja on jo varjossa
                }
            }
        }

        // Tarkista t‰m‰n objektin varjo
        CheckShadow();

        if (!isPlayerInsideAnyShadow)
        {
            // Jos pelaaja ei ole miss‰‰n varjossa, restarttaa scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void CheckShadow()
    {
        Vector3 lightPosition = new Vector3(light.transform.position.x, light.transform.position.y, 0f);
        Vector3 currentPosition = new Vector3(transform.position.x, transform.position.y, 0f);

        Vector3 leftUpEdge = currentPosition - new Vector3(spriteWidth / 2, -spriteHeight / 2, 0f);
        Vector3 rightUpEdge = currentPosition + new Vector3(spriteWidth / 2, spriteHeight / 2, 0f);
        Vector3 leftDownEdge = currentPosition - new Vector3(spriteWidth / 2, spriteHeight / 2, 0f);
        Vector3 rightDownEdge = currentPosition + new Vector3(spriteWidth / 2, -spriteHeight / 2, 0f);

        // Extend lines
        Vector3 extendedLeftUp = leftUpEdge + (leftUpEdge - lightPosition).normalized * extendDistance;
        Vector3 extendedRightUp = rightUpEdge + (rightUpEdge - lightPosition).normalized * extendDistance;
        Vector3 extendedLeftDown = leftDownEdge + (leftDownEdge - lightPosition).normalized * extendDistance;
        Vector3 extendedRightDown = rightDownEdge + (rightDownEdge - lightPosition).normalized * extendDistance;

        // Tarkista ettei viivat mene liian alas
        if (extendedLeftUp.y < minY)
        {
            float t = (minY - leftUpEdge.y) / (extendedLeftUp.y - leftUpEdge.y);
            extendedLeftUp = leftUpEdge + t * (extendedLeftUp - leftUpEdge);
        }

        if (extendedRightUp.y < minY)
        {
            float t = (minY - rightUpEdge.y) / (extendedRightUp.y - rightUpEdge.y);
            extendedRightUp = rightUpEdge + t * (extendedRightUp - rightUpEdge);
        }

        if (extendedLeftDown.y < minY)
        {
            float t = (minY - leftDownEdge.y) / (extendedLeftDown.y - leftDownEdge.y);
            extendedLeftDown = leftDownEdge + t * (extendedLeftDown - leftDownEdge);
        }

        if (extendedRightDown.y < minY)
        {
            float t = (minY - rightDownEdge.y) / (extendedRightDown.y - rightDownEdge.y);
            extendedRightDown = rightDownEdge + t * (extendedRightDown - rightDownEdge);
        }

        // Piirr‰ alkuper‰iset viivat ja suorita varjojen tarkistus
        DrawLines(extendedLeftUp, extendedRightDown);
        DrawLines(extendedLeftDown, extendedRightUp);
        DrawLines(extendedRightUp, extendedLeftDown);
        DrawLines(extendedRightDown, extendedLeftUp);

        // Tarkista, onko pelaaja varjon sis‰ll‰
        bool playerInsideX = IsPlayerInside(extendedLeftUp, extendedRightDown, leftDownEdge, rightDownEdge);
        bool playerInsideY = IsPlayerInside(extendedLeftDown, extendedRightUp, leftDownEdge, rightDownEdge);

        // P‰ivit‰ isPlayerInsideAnyShadow-lippu
        isPlayerInsideAnyShadow = playerInsideX || playerInsideY;
    }

    void DrawLines(Vector3 extendedEdge1, Vector3 extendedEdge2)
    {
        Debug.DrawLine(extendedEdge1, light.transform.position, Color.red);
        Debug.DrawLine(extendedEdge1, extendedEdge2, Color.red);
    }

    bool IsPlayerInside(Vector3 extendedEdge1, Vector3 extendedEdge2, Vector3 leftDownEdge, Vector3 rightDownEdge)
    {
        GameObject player = GameObject.FindWithTag("PLAYER");

        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Please make sure the player has the 'Player' tag.");
            return false;
        }

        return (player.transform.position.x > extendedEdge1.x && player.transform.position.x < extendedEdge2.x &&
                player.transform.position.y < leftDownEdge.y && player.transform.position.y < rightDownEdge.y);
    }

    public bool IsPlayerInside()
    {
        return isPlayerInsideAnyShadow;
    }
}
