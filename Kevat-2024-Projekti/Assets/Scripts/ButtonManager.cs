using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    //T�m� funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata t�h�n skeneen. T�m� my�s asettaa game skenen n�kyviin. 
    public void Play()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    //T�m� funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata t�h�n skeneen. T�m� my�s asettaa mainmenu skenen n�kyviin. 
    public void MainMenu()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    //T�m� funktio asettaa pelin ajaksi 1 jolloin peli toimii, tulostaa konsoliin sanan quit ja sulkee pelin.
    public void Quit()
    {
        Time.timeScale = 1.0f;
        Debug.Log("QUIT");
        Application.Quit();
    }

    //T�m� funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata t�h�n skeneen. T�m� my�s asettaa settings skenen n�kyviin. 
    public void Settings()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Settings");
    }

    //T�m� funktio asettaa sen skenen n�kyviin, mik� on viimeisimm�ksi tallennettu playerprefsin savedsceneen.
    public void Back()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
}