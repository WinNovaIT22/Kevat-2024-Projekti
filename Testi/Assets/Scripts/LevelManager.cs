using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float fadeTime;
    public Image fadePanel;
    [SerializeField] public TextMeshProUGUI[] levelText;
    [SerializeField] public GameObject[] lockIcon;

    private const int TotalLevels = 26;
    private int completedLevels = 0;

    public bool resetLevels = false;

    void Start()
    {
        if (resetLevels)
        {
            PlayerPrefs.SetInt("UnlockedLevels", 3);
        }
    }

    void Update()
    {
        UpdateLevelButtons();
        Debug.Log(PlayerPrefs.GetInt("UnlockedLevels"));
    }

    private void UpdateLevelButtons()
    {
        for (int i = 0; i < TotalLevels; i++)
        {
            bool isUnlocked = PlayerPrefs.GetInt("UnlockedLevels") > i + 3;
            levelText[i].gameObject.SetActive(isUnlocked);
            lockIcon[i].SetActive(!isUnlocked);
        }
    }

    public void LoadLevel(int levelIndex)
    {
        int sceneIndex = levelIndex + 1;
        Debug.Log(sceneIndex);
        if (PlayerPrefs.GetInt("UnlockedLevels") -2 >= sceneIndex)
        {
            StartCoroutine(LevelSequence(sceneIndex));
        }
        else
        {
            Debug.Log("Kenttä ei ole vielä auki.");
        }
    }
    
    public void Back() => StartCoroutine(BackSequence());

    IEnumerator BackSequence()
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    IEnumerator LevelSequence(int levelIndex)
    {
        fadePanel.DOFade(1, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        DOTween.KillAll();
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;

        // Assume the level is completed when transitioning to the next level.
        completedLevels = Mathf.Max(completedLevels, levelIndex - 2);

        // Save the completed levels to PlayerPrefs.
        PlayerPrefs.SetInt("CompletedLevels", completedLevels);

        SceneManager.LoadScene($"Level {levelIndex}");
    }
}
