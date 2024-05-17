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
            if (level >= 0 && level <= methods.Length)
            {
                methods[level].Invoke(this, null); //methods[level - 1]
            }
        }
        
    }

    // Esimerkkinä eri levelien metodit
    public void level1Times()
    {
        float star3time = 4f;
        float star2time = 6f;
        float star1time = 8f;

        PlayerPrefs.SetInt("Level1FirstTime", 1);
        if (PlayerPrefs.GetInt("Level1FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 4 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level1Stars", 3);
                Debug.Log("Level 1: 3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 6 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level1Stars", 2);
                Debug.Log("Level 1: 2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 8 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level1Stars", 1);
                Debug.Log("Level 1: 1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level1Stars", 0);
                Debug.Log("Level 1: ei tähtiä");
            }
            PlayerPrefs.SetInt("Level1FirstTime", 0);
        }

    }

    public void level2Times()
    {
        float star3time = 4f;
        float star2time = 6f;
        float star1time = 8f;

        PlayerPrefs.SetInt("Level2FirstTime", 1);
        if (PlayerPrefs.GetInt("Level2FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 4 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level2Stars", 3);
                Debug.Log("Level 2: 3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 6 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level2Stars", 2);
                Debug.Log("Level 2: 2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 8 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level2Stars", 1);
                Debug.Log("Level 2: 1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level2Stars", 0);
                Debug.Log("Level 2: ei tähtiä");
            }
            PlayerPrefs.SetInt("Level2FirstTime", 0);
        }
    }
    public void level3Times()
    {
        float star3time = 5f;
        float star2time = 6f;
        float star1time = 7f;
        PlayerPrefs.SetInt("Level3FirstTime", 1);
        if (PlayerPrefs.GetInt("Level3FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 5 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level3Stars", 3);
                Debug.Log("Level 3: 3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 6 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level3Stars", 2);
                Debug.Log("Level 3: 2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 7 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level3Stars", 1);
                Debug.Log("Level 3: 1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level3Stars", 0);
                Debug.Log("Level 3: ei tähtiä");
            }
            PlayerPrefs.SetInt("Level3FirstTime", 0);
        }
    }

    public void level4Times()
    {

        float star3time = 19f;
        float star2time = 21f;
        float star1time = 22f;
        PlayerPrefs.SetInt("Level4FirstTime", 1);
        if (PlayerPrefs.GetInt("Level4FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level4Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level4Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level4Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level4Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level4FirstTime", 0);
        }

    }

    public void level5Times()
    {
        float star3time = 9f;
        float star2time = 10.5f;
        float star1time = 12f;
        PlayerPrefs.SetInt("Level5FirstTime", 1);
        if (PlayerPrefs.GetInt("Level5FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level5Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level5Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level5Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level5Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level5FirstTime", 0);
        }
    }

    public void level6Times()
    {
        float star3time = 12f;
        float star2time = 14f;
        float star1time = 15f;

        PlayerPrefs.SetInt("Level6FirstTime", 1);
        if (PlayerPrefs.GetInt("Level6FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level6Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level6Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level6Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level6Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level6FirstTime", 0);
        }
    }
    public void level7Times()
    {
        float star3time = 18f;
        float star2time = 19.5f;
        float star1time = 21f;
        PlayerPrefs.SetInt("Level7FirstTime", 1);
        if (PlayerPrefs.GetInt("Level7FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level7Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level7Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level7Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level7Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level7FirstTime", 0);
        }

    }

    public void level8Times()
    {
        float star3time = 20f;
        float star2time = 22f;
        float star1time = 24f;
        PlayerPrefs.SetInt("Level8FirstTime", 1);
        if (PlayerPrefs.GetInt("Level8FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level8Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level8Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level8Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level8Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level8FirstTime", 0);
        }
    }

    public void level9Times()
    {
        float star3time = 13f;
        float star2time = 17f;
        float star1time = 23f;
        PlayerPrefs.SetInt("Level9FirstTime", 1);
        if (PlayerPrefs.GetInt("Level9FirstTime") == 1)
        {
            if (seconds <= star3time && minutes <= 1)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level9Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes <= 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level9Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes <= 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level9Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level9Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level9FirstTime", 0);
        }
    }

    public void level10Times()
    {
        float star3time = 9f;
        float star2time = 11f;
        float star1time = 13f;
        PlayerPrefs.SetInt("Level10FirstTime", 1);
        if (PlayerPrefs.GetInt("Level10FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level10Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level10Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level10Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level10Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level10FirstTime", 0);
        }
    }

    public void level11Times()
    {
        float star3time = 31f;
        float star2time = 35f;
        float star1time = 40f;
        PlayerPrefs.SetInt("Level11FirstTime", 1);
        if (PlayerPrefs.GetInt("Level11FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level11Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level11Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level11Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level11Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level11FirstTime", 0);
        }
    }
    public void level12Times()
    {
        float star3time = 33f;
        float star2time = 35f;
        float star1time = 38f;
        PlayerPrefs.SetInt("Level12FirstTime", 1);
        if (PlayerPrefs.GetInt("Level12FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level12Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level12Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level12Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level12Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level12FirstTime", 0);
        }
    }

    public void level13Times()
    {
        float star3time = 19f;
        float star2time = 23f;
        float star1time = 27f;
        PlayerPrefs.SetInt("Level13FirstTime", 1);
        if (PlayerPrefs.GetInt("Level13FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level13Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level13Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level13Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level13Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level13FirstTime", 0);
        }
    }
    public void level14Times()
    {
        float star3time = 10f;
        float star2time = 11.5f;
        float star1time = 13f;
        PlayerPrefs.SetInt("Level14FirstTime", 1);
        if (PlayerPrefs.GetInt("Level14FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level14Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level14Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level14Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level14Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level14FirstTime", 0);
        }
    }

    public void level15Times()
    {
        float star3time = 10f;
        float star2time = 11f;
        float star1time = 12f;
        PlayerPrefs.SetInt("Level15FirstTime", 1);
        if (PlayerPrefs.GetInt("Level15FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level15Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level15Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level15Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level15Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level15FirstTime", 0);
        }
    }

    public void level16Times()
    {
        float star3time = 50f;
        float star2time = 53f;
        float star1time = 56f;
        PlayerPrefs.SetInt("Level16FirstTime", 1);
        if (PlayerPrefs.GetInt("Level16FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level16Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level16Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level16Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level16Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level16FirstTime", 0);
        }
    }
    public void level17Times()
    {
        float star3time = 48f;
        float star2time = 55f;
        float star1time = 60f;
        PlayerPrefs.SetInt("Level17FirstTime", 1);
        if (PlayerPrefs.GetInt("Level17FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level17Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level17Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level17Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level17Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level17FirstTime", 0);
        }
    }

    public void level18Times()
    {
        float star3time = 15f;
        float star2time = 18f;
        float star1time = 22f;
        PlayerPrefs.SetInt("Level18FirstTime", 1);
        if (PlayerPrefs.GetInt("Level18FirstTime") == 1)
        {
            if (seconds <= star3time && minutes == 0)
            {
                //alle 19 sekunttia = 3 tähteä   
                PlayerPrefs.SetInt("Level18Stars", 3);
                Debug.Log("3 tähteä");
            }

            else if (seconds <= star2time && minutes == 0)
            {
                //alle 21 sekunttia = 2 tähteä
                PlayerPrefs.SetInt("Level18Stars", 2);
                Debug.Log("2 tähteä");
            }

            else if (seconds <= star1time && minutes == 0)
            {
                //alle 22 sekunttia = 1 tähti
                PlayerPrefs.SetInt("Level18Stars", 1);
                Debug.Log("1 tähti");
            }

            else
            {
                //ei tähtiä
                PlayerPrefs.SetInt("Level18Stars", 0);
                Debug.Log("ei tähtiä");
            }
            PlayerPrefs.SetInt("Level18FirstTime", 0);
        }
    }
}