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

public class LevelManager : MonoBehaviour
{
    public float fadeTime;
    public Image fadePanel;

    [SerializeField] public TextMeshProUGUI[] levelText;
    [SerializeField] public GameObject[] lockIcon;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") >= 4)
        {
            levelText[0].gameObject.SetActive(true);
            lockIcon[0].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 5)
        {
            levelText[1].gameObject.SetActive(true);
            lockIcon[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 6)
        {
            levelText[2].gameObject.SetActive(true);
            lockIcon[2].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 7)
        {
            levelText[3].gameObject.SetActive(true);
            lockIcon[3].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 8)
        {
            levelText[4].gameObject.SetActive(true);
            lockIcon[4].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 9)
        {
            levelText[5].gameObject.SetActive(true);
            lockIcon[5].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 10)
        {
            levelText[6].gameObject.SetActive(true);
            lockIcon[6].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 11)
        {
            levelText[7].gameObject.SetActive(true);
            lockIcon[7].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 12)
        {
            levelText[8].gameObject.SetActive(true);
            lockIcon[8].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 13)
        {
            levelText[9].gameObject.SetActive(true);
            lockIcon[9].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 14)
        {
            levelText[10].gameObject.SetActive(true);
            lockIcon[10].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 15)
        {
            levelText[11].gameObject.SetActive(true);
            lockIcon[11].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 16)
        {
            levelText[12].gameObject.SetActive(true);
            lockIcon[12].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 17)
        {
            levelText[13].gameObject.SetActive(true);
            lockIcon[13].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 18)
        {
            levelText[14].gameObject.SetActive(true);
            lockIcon[14].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 19)
        {
            levelText[15].gameObject.SetActive(true);
            lockIcon[15].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 20)
        {
            levelText[16].gameObject.SetActive(true);
            lockIcon[16].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 21)
        {
            levelText[17].gameObject.SetActive(true);
            lockIcon[17].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 22)
        {
            levelText[18].gameObject.SetActive(true);
            lockIcon[18].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 23)
        {
            levelText[19].gameObject.SetActive(true);
            lockIcon[19].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 24)
        {
            levelText[20].gameObject.SetActive(true);
            lockIcon[20].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 25)
        {
            levelText[21].gameObject.SetActive(true);
            lockIcon[21].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 26)
        {
            levelText[22].gameObject.SetActive(true);
            lockIcon[22].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 27)
        {
            levelText[23].gameObject.SetActive(true);
            lockIcon[23].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 28)
        {
            levelText[24].gameObject.SetActive(true);
            lockIcon[24].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 29)
        {
            levelText[25].gameObject.SetActive(true);
            lockIcon[25].SetActive(false);
        }

        if (PlayerPrefs.GetInt("UnlockedLevels") >= 30)
        {
            levelText[26].gameObject.SetActive(true);
            lockIcon[26].SetActive(false);
        }
    }



    public void Level1()
    {
        StartCoroutine(Level1Sequence());

    }

    
    public void Level2()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 3)
        {
            StartCoroutine(Level2Sequence());
        }
        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }


    public void Level3()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 4)
        {
            StartCoroutine(Level3Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
            

    }

   
    public void Level4()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 5)
        {
            StartCoroutine(Level4Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
        

    }

    public void Level5()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 5)
        {
            StartCoroutine(Level5Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
        

    }
    public void Level6()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 6)
        {
            StartCoroutine(Level6Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level7()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 7)
        {
            StartCoroutine(Level7Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level8()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 8)
        {
            StartCoroutine(Level8Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level9()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 9)
        {
            StartCoroutine(Level9Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level10()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 10)
        {
            StartCoroutine(Level10Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level11()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 11)
        {
            StartCoroutine(Level11Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level12()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 12)
        {
            StartCoroutine(Level12Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level13()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 13)
        {
            StartCoroutine(Level13Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level14()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 14)
        {
            StartCoroutine(Level14Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level15()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 15)
        {
            StartCoroutine(Level15Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level16()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 16)
        {
            StartCoroutine(Level16Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level17()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 17)
        {
            StartCoroutine(Level17Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level18()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 18)
        {
            StartCoroutine(Level18Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level19()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 19)
        {
            StartCoroutine(Level19Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level20()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 20)
        {
            StartCoroutine(Level20Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level21()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 21)
        {
            StartCoroutine(Level21Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level22()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 22)
        {
            StartCoroutine(Level22Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level23()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 23)
        {
            StartCoroutine(Level23Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level24()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 24)
        {
            StartCoroutine(Level24Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level25()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 25)
        {
            StartCoroutine(Level25Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level26()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 26)
        {
            StartCoroutine(Level26Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    public void Level27()
    {
        if (PlayerPrefs.GetInt("UnlockedLevels") > 27)
        {
            StartCoroutine(Level27Sequence());
        }

        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
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

    IEnumerator Level1Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator Level2Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 2");
    }

    IEnumerator Level3Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 3");
    }

    IEnumerator Level4Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 4");
    }

    IEnumerator Level5Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 5");
    }

    IEnumerator Level6Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 6");
    }

    IEnumerator Level7Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 7");
    }

    IEnumerator Level8Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 8");
    }

    IEnumerator Level9Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 9");
    }

    IEnumerator Level10Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 10");
    }

    IEnumerator Level11Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 11");
    }

    IEnumerator Level12Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 12");
    }

    IEnumerator Level13Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 13");
    }

    IEnumerator Level14Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 14");
    }

    IEnumerator Level15Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 15");
    }

    IEnumerator Level16Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 16");
    }

    IEnumerator Level17Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 17");
    }

    IEnumerator Level18Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 18");
    }

    IEnumerator Level19Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 19");
    }

    IEnumerator Level20Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 20");
    }

    IEnumerator Level21Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 21");
    }

    IEnumerator Level22Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 22");
    }

    IEnumerator Level23Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 23");
    }

    IEnumerator Level24Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 24");
    }

    IEnumerator Level25Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 25");
    }

    IEnumerator Level26Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 26");
    }

    IEnumerator Level27Sequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level 27");
    }


}