using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowDetection : MonoBehaviour
{
    public GameObject lightSource;
    private float spriteWidth;
    private float spriteHeight;

    static List<ShadowDetection> allShadows = new List<ShadowDetection>(); // Lista kaikista varjoista
    bool isInsideShadow = false; // Tarkistaa, oletko t‰m‰n varjon sis‰ll‰

    float extendDistance = 20f;
    float minY = -8f;

    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x * transform.lossyScale.x;
        spriteHeight = sRenderer.sprite.bounds.size.y * transform.lossyScale.y;

        // Lis‰‰ t‰m‰ varjo kaikkien varjojen listaan
        allShadows.Add(this);
    }

    void Update()
    {
        // Resetoi lipun jokaisen framen alussa
        bool isPlayerInsideAnyShadow = false;

        // Tarkista kaikkien varjojen tila
        foreach (ShadowDetection shadow in allShadows)
        {
            shadow.CheckShadow();
            if (shadow.isInsideShadow)
            {
                isPlayerInsideAnyShadow = true;
                break; // Jos pelaaja on jo miss‰‰n varjossa, ei tarvitse tarkistaa en‰‰ muita
            }
        }

        if (!isPlayerInsideAnyShadow)
        {
            // Jos pelaaja ei ole miss‰‰n varjossa, restarttaa scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void CheckShadow()
    {
        Vector3 lightPosition = lightSource.transform.position;
        Vector3 currentPosition = transform.position;

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

        // Tarkista, onko pelaaja t‰m‰n varjon sis‰ll‰
        isInsideShadow = IsPlayerInside(extendedLeftUp, extendedRightDown, leftDownEdge, rightDownEdge) ||
                         IsPlayerInside(extendedLeftDown, extendedRightUp, leftDownEdge, rightDownEdge);
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
}
