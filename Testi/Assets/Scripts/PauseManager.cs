using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject others;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                PlayerPrefs.SetInt("isPaused", 0);
                isPaused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                others.SetActive(true);
            }

            else
            {
                PlayerPrefs.SetInt("isPaused", 1);
                isPaused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                others.SetActive(false);
            }
        }
    }

    public void Continue()
    {
        if (isPaused)
        {
            PlayerPrefs.SetInt("isPaused", 0);
            isPaused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            others.SetActive(true);
        }

        else
        {
            PlayerPrefs.SetInt("isPaused", 1);
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            others.SetActive(false);
        }
    }
}
