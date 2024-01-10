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

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa game skenen näkyviin. 
    public void Play()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa mainmenu skenen näkyviin. 
    public void MainMenu()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    //Tämä funktio asettaa pelin ajaksi 1 jolloin peli toimii, tulostaa konsoliin sanan quit ja sulkee pelin.
    public void Quit()
    {
        Time.timeScale = 1.0f;
        Debug.Log("QUIT");
        Application.Quit();
    }

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa settings skenen näkyviin. 
    public void Settings()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Settings");
    }

    //Tämä funktio asettaa sen skenen näkyviin, mikä on viimeisimmäksi tallennettu playerprefsin savedsceneen.
    public void Back()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
}