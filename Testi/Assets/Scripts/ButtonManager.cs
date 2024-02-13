using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.LookDev;
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
        if (resetPrefs)
        {
            PlayerPrefs.DeleteAll();
        }

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
        StartCoroutine(MainMenuSequence());
    }

    public void Levels()
    {
        StartCoroutine(LevelsSequence());
    }

    public void Quit()
    {
        StartCoroutine(QuitSequence());

    }

    public void Settings()
    {
        StartCoroutine(SettingsSequence());

    }

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
        SceneManager.LoadScene(PlayerPrefs.GetInt("UnlockedLevels"));
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

    IEnumerator LevelsSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Levels");
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