using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private bool GameMenuBool = false;

    public GameObject BackgroundActivate;
    public GameObject GameMenuActivate;
    public GameObject Shade;

    public GameObject character;

    public void Update()
    {
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (character.GetComponent<MovementScript>().isDead == true)
        {
            GameMenuActivate.SetActive(true);
            BackgroundActivate.SetActive(true);
            Shade.SetActive(true);
            GameMenuBool = true;
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
