using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public float fadeTime;
    public Image fadePanel;
    public bool resetPrefs = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") == 0)
        {
            PlayerPrefs.SetInt("UnlockedLevels", 3);
        }
    }

  
    public void Play()
    {
        
        StartCoroutine(PlaySequence());
    }

    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(MainMenuSequence());
    }

    public void Levels()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LevelsSequence());
    }

    public void Quit()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(QuitSequence());
    }

    public void Settings()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(SettingsSequence());
    }

    public void Back()
    {
        StartCoroutine(BackSequence());
    }

    IEnumerator BackSequence()
    {
        Debug.Log("Takaisin");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    IEnumerator PlaySequence()
    {
        Debug.Log("Kenttä x");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("UnlockedLevels"));
    }

    IEnumerator MainMenuSequence()
    {
        Debug.Log("MainMenu");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LevelsSequence()
    {
        Debug.Log("LevelMenu");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Levels");
    }

    IEnumerator SettingsSequence()
    {
        Debug.Log("Asetukset");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Settings");
    }

    IEnumerator QuitSequence()
    {
        Debug.Log("QUIT");
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        Time.timeScale = 1.0f;
        Debug.Log("QUIT");
        Application.Quit();
    }

}