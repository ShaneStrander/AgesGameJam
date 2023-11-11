using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuScript : MonoBehaviour
{
    private bool GameMenuBool = false;

    public GameObject BackgroundActivate;
    public GameObject GameMenuActivate;

    public void Update()
    {
        GameMenu();
    }

    public void GameMenu()
    {
        if (Input.GetKeyDown("escape") && GameMenuBool == false)
        {
            Debug.Log("yeehaw");
            GameMenuActivate.SetActive(true);
            BackgroundActivate.SetActive(true);
            GameMenuBool = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("escape") && GameMenuBool == true)
        {
            GameMenuActivate.SetActive(false);
            BackgroundActivate.SetActive(false);
            GameMenuBool = false;
            Time.timeScale = 1;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
