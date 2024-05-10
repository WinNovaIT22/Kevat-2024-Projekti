using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField] public GameObject[] stars;
    int levelNumb = 1;
    int inumb = 0;
    public void GiveStars()
    {
        
        LevelStars();
    }

    public void LevelStars()
    {
        for (int j = 0; j < 18; j++)
        {
            for (int i = inumb; i < PlayerPrefs.GetInt("Level" + levelNumb.ToString() + "Stars") + inumb; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
            Debug.Log("Level" + levelNumb  + ": " + PlayerPrefs.GetInt("Level" + levelNumb + "Stars") + " Stars");
            levelNumb++;
            inumb += 3;
        }
        
    }
}
