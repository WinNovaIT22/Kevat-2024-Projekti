using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    //Lista numeroille siin‰ j‰rjestyksess‰ miss‰ napit kuuluu avata
    public GameObject[] unPressedButtons = new GameObject[6];
    public GameObject[] PressedButtons = new GameObject[6];
    private int[] buttonOrder = { 3, 4, 1, 5, 2, 6 };
    private bool isActivated = false;
    private int number = 0;
    private int whatButton = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {

            if (whatButton == buttonOrder[number])
            {
                if (number == 5)
                {
                    PressedButtons[whatButton - 1].gameObject.SetActive(true);
                    unPressedButtons[whatButton - 1].gameObject.SetActive(false);
                    Debug.Log("Nappi " + whatButton + " oli oikea.");
                    Debug.Log("L‰p‰isit houneen!");
                }

                else
                {
                    Debug.Log("Nappi " + whatButton + " oli oikea.");
                    number++;

                    PressedButtons[whatButton - 1].gameObject.SetActive(true);
                    unPressedButtons[whatButton - 1].gameObject.SetActive(false);
                }
                
            }

            else
            {
                Debug.Log("Nappi " + whatButton + " oli v‰‰r‰.");
                for (int i = 0; i < 5; i++)
                {
                    PressedButtons[i].gameObject.SetActive(false);
                    unPressedButtons[i].gameObject.SetActive(true);
                }
                number = 0;
            }
            
            isActivated = !isActivated;
        }
    }

    //Ratkaisu j‰rjestys 3,4,1,5,2,6
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 1;
                isActivated = true;
                Debug.Log("Ensimm‰inen nappi painettu");
            }
            
        }

        if (collision.gameObject.CompareTag("Button2"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 2;
                isActivated = true;
                Debug.Log("Toinen nappi painettu");
            }

        }

        if (collision.gameObject.CompareTag("Button3"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 3;
                isActivated = true;
                Debug.Log("Kolmas nappi painettu");
            }

        }

        if (collision.gameObject.CompareTag("Button4"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 4;
                isActivated = true;
                Debug.Log("Nelj‰s nappi painettu");
            }

        }

        if (collision.gameObject.CompareTag("Button5"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 5;
                isActivated = true;
                Debug.Log("Viides nappi painettu");
            }

        }

        if (collision.gameObject.CompareTag("Button6"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                whatButton = 6;
                isActivated = true;
                Debug.Log("Kuudes nappi painettu");
            }

        }
    }
}
