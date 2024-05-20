using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnFirstLaunch : MonoBehaviour
{
    public bool resetOnLaunch = false;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("IDK") == 0)
        {
            PlayerPrefs.SetInt("FirstLaunch", 0);
            PlayerPrefs.SetInt("IDK", 1);
        }
        if (resetOnLaunch)
        {
            if(PlayerPrefs.GetInt("FirstLaunch") == 0)
            {
                PlayerPrefs.SetInt("FirstLaunch", 1);
            }
        }
        
        if (resetOnLaunch && PlayerPrefs.GetInt("FirstLaunch") == 1)
        {
            PlayerPrefs.SetInt("ResetLevels", 1);
            PlayerPrefs.SetInt("ResetStars", 1);
            PlayerPrefs.SetInt("FirstLaunch", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
