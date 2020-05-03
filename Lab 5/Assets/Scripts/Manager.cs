using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Manager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject FirstControl;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        isPaused = false;

        if(pauseMenu)
            pauseMenu.SetActive(false);

        if (FirstControl)
            FirstControl.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    public void TogglePause()
    {
        if (pauseMenu)
        {

            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0.0f : 1.0f;

            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

        }

    }

    public void ExitScene()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
        if (FirstControl)
            FirstControl.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeVolume(int vol) 
    {
        gameObject.GetComponent<AudioSource>().volume = vol;
    }
}
