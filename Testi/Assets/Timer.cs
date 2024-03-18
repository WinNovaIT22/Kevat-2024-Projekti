using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI timerText;
    float elapsedTime;
    int level = 0;
    MethodInfo[] methods;
    public int seconds;
    public int minutes;

    // Start is called before the first frame update
    void Start()
    {
        // Haetaan kaikki public metodit tästä luokasta, joiden nimi alkaa "level".
        methods = typeof(Timer).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        minutes = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        level = SceneManager.GetActiveScene().buildIndex - 2;

        Debug.Log(level);

        if (PlayerPrefs.GetInt("GOAL") == 1)
        {
            // Kutsutaan funktiota levelin mukaan, jos level on suurempi kuin 0 ja pienempi tai yhtäsuuri kuin metodien määrä.
            if (level > 0 && level <= methods.Length)
            {
                methods[level - 1].Invoke(this, null);
            }
        }
        
    }

    // Esimerkkinä eri levelien metodit
    public void level1Times()
    {
        float star3time = 4f;
        float star2time = 6f;
        float star1time = 8f;

        Debug.Log("Level 1");

        if (seconds <= star3time && minutes == 0)
        {
            //alle 4 sekunttia = 3 tähteä   
        }

        else if (seconds <= star2time && minutes == 0)
        {
            //alle 6 sekunttia = 2 tähteä
        }

        else if(seconds <= star1time && minutes == 0){
            //alle 8 sekunttia = 1 tähti
        }

        else
        {
            //ei tähtiä
        }

    }

    public void level2Times()
    {
        Debug.Log("Level 2");
    }
    public void level3Times()
    {
        Debug.Log("Level 3");
    }

    public void level4Times()
    {
        Debug.Log("Level 4");
    }

    public void level5Times()
    {
        Debug.Log("Level 1");
    }

    public void level6Times()
    {
        Debug.Log("Level 2");
    }
    public void level7Times()
    {
        Debug.Log("Level 3");
    }

    public void level8Times()
    {
        Debug.Log("Level 4");
    }
}