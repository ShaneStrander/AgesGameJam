using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuScript : MonoBehaviour
{
    private bool GameMenuBool = false;

    public GameObject BackgroundActivate;
    public GameObject GameMenuActivate;
    public GameObject Shade;

    public void Update()
    {
        GameMenu();
    }

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void GameMenu()
    {
        if (Input.GetKeyDown("escape") && GameMenuBool == false)
        {
            Debug.Log("yeehaw");
            GameMenuActivate.SetActive(true);
            BackgroundActivate.SetActive(true);
            Shade.SetActive(true);
            GameMenuBool = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown("escape") && GameMenuBool == true)
        {
            GameMenuActivate.SetActive(false);
            BackgroundActivate.SetActive(false);
            Shade.SetActive(false);
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

    public void ContinueGame()
    {
        GameMenuActivate.SetActive(false);
        BackgroundActivate.SetActive(false);
        Shade.SetActive(false);
        GameMenuBool = false;
        Time.timeScale = 1;
    }
}
