using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowDetection : MonoBehaviour
{
    public GameObject light;
    public GameObject player;
    private float spriteWidth;
    private float spriteHeight;

    public bool playerInsideX = false;
    public bool playerInsideY = false;
    float extendDistance = 20f; // Muuta tähän haluamasi etäisyys
    float minY = -8f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x * transform.lossyScale.x;
        spriteHeight = sRenderer.sprite.bounds.size.y * transform.lossyScale.y;
    }

    // Update is called once per frame
    void Update()
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

        //Tarkista ettei viivat mene liian alas
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


        //Draw initial lines

        if (extendedLeftUp.x < extendedLeftDown.x)
        {
            Debug.DrawLine(leftUpEdge, lightPosition, Color.red);
            Debug.DrawLine(leftUpEdge, extendedLeftUp, Color.red);
            if (player.transform.position.x > extendedLeftUp.x && player.transform.position.x < extendedRightDown.x)
            {
                if (player.transform.position.y < leftDownEdge.y && player.transform.position.y < rightDownEdge.y)
                {
                    playerInsideY = true;
                    playerInsideX = true;
                }
                else
                {
                    playerInsideY = false;
                    playerInsideX = false;
                }
                
            }
            else
            {
                playerInsideX = false;
            }
            
        }

        if(extendedLeftDown.x < extendedLeftUp.x)
        {
            Debug.DrawLine(leftDownEdge, lightPosition, Color.blue);
            Debug.DrawLine(leftDownEdge, extendedLeftDown, Color.blue);
            if (player.transform.position.x > extendedLeftDown.x && player.transform.position.x < extendedRightUp.x)
            {
                if (player.transform.position.y < leftDownEdge.y && player.transform.position.y < rightDownEdge.y)
                {
                    playerInsideY = true;
                    playerInsideX = true;
                }
                else
                {
                    playerInsideY = false;
                    playerInsideX = false;
                }
            }
            else
            {
                playerInsideX = false;
            }
            
        }

        if (extendedRightUp.x > extendedRightDown.x)
        {
            if (player.transform.position.x > extendedLeftDown.x && player.transform.position.x < extendedRightUp.x)
            {
                playerInsideX = true;
            }
            else
            {
                playerInsideX = false;
            }
            Debug.DrawLine(rightUpEdge, lightPosition, Color.green);
            Debug.DrawLine(rightUpEdge, extendedRightUp, Color.green);
        }

        if (extendedRightDown.x > extendedRightUp.x)
        {
            Debug.DrawLine(rightDownEdge, lightPosition, Color.yellow);
            Debug.DrawLine(rightDownEdge, extendedRightDown, Color.yellow);
            if (player.transform.position.x > extendedLeftUp.x && player.transform.position.x < extendedRightDown.x)
            {
                playerInsideX = true;
            }
            else
            {
                playerInsideX = false;
            }

            
        }

        //Player is in shadows
        if (playerInsideX)
        {
            Debug.Log("Player in the shadows!");
            PlayerPrefs.SetInt("InShadow", 1);
        }

        else
        {
            Debug.Log("Player not in the shadows!");
            PlayerPrefs.SetInt("InShadow", 0);
        }

        if (playerInsideY)
        {
            Debug.Log("Player in the shadows!");
            PlayerPrefs.SetInt("InShadow", 1);
        }

        else
        {
            Debug.Log("Player not in the shadows!");
            PlayerPrefs.SetInt("InShadow", 0);
        }

        if (PlayerPrefs.GetInt("InShadow") == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
