using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public float fadeTime;
    public Image fadePanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa game skenen näkyviin. 
    public void Play()
    {
        StartCoroutine(PlaySequence());

    }

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa mainmenu skenen näkyviin. 
    public void MainMenu()
    {
        StartCoroutine(MainMenuSequence());

    }

    //Tämä funktio asettaa pelin ajaksi 1 jolloin peli toimii, tulostaa konsoliin sanan quit ja sulkee pelin.
    public void Quit()
    {
        StartCoroutine(QuitSequence());

    }

    //Tämä funktio asettaa savedscene playerprefsiin nykyisen scenen arvon, jotta back funktiossa voidaan palata tähän skeneen. Tämä myös asettaa settings skenen näkyviin. 
    public void Settings()
    {
        StartCoroutine(SettingsSequence());

    }

    //Tämä funktio asettaa sen skenen näkyviin, mikä on viimeisimmäksi tallennettu playerprefsin savedsceneen.
    public void Back()
    {
        StartCoroutine(BackSequence());
    }

    IEnumerator BackSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    IEnumerator PlaySequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }

    IEnumerator MainMenuSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator SettingsSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Settings");
    }

    IEnumerator QuitSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        Time.timeScale = 1.0f;
        Debug.Log("QUIT");
        Application.Quit();
    }

}