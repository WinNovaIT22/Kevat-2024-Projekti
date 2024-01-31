using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    public bool paused = false;
    [SerializeField] public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                paused = true;
            }

            else
            {
                paused = false;
            }
        }

        while (paused)
        {
            if (isPaused == false)
            {
                isPaused = true;
                Time.timeScale = 0f;
                pauseMenu.gameObject.SetActive(true);
            }
            else
            {
                isPaused = false;
                Time.timeScale = 1f;
                pauseMenu.gameObject.SetActive(false);
            }
        }
    }

    public void pauseButton()
    {
        if (!paused)
        {
            paused = true;
        }

        else
        {
            paused = false;
        }
    }
}
