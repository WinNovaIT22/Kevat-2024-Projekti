using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] public GameObject[] stars;
    int levelNumb = 1;
    int inumb = 0;
    int numb = 1;
    public bool resetStars = false;
    public void GiveStars()
    {
        if (resetStars || PlayerPrefs.GetInt("ResetStars") == 1)
        {
            for (int i = 1; i < 18; i++)
            {
                Debug.Log("Resetting stars");
                PlayerPrefs.SetInt("Level" + i.ToString() + "Stars", 0);
                PlayerPrefs.SetInt("Level" + numb.ToString() + "FirstTime", 0);
                //Debug.Log("Level" + i + ": " + PlayerPrefs.GetInt("Level" + i + "Stars") + " Stars");
            }
            PlayerPrefs.SetInt("ResetStars", 0);
        }
        else
        {
            LevelStars();
        }
    }

    public void LevelStars()
    {
        for (int j = 0; j < 17; j++)
        {
            for (int i = inumb; i < PlayerPrefs.GetInt("Level" + levelNumb.ToString() + "Stars") + inumb; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
            //Debug.Log("Level" + levelNumb  + ": " + PlayerPrefs.GetInt("Level" + levelNumb + "Stars") + " Stars");
            levelNumb++;
            inumb += 3;
        }
        
    }
}
