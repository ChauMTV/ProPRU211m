using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour

{
    

    public void Playgame()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Quitgame()
    {
        SceneManager.LoadScene("Scense0");
    }

    public void Slectmap()
    {
        SceneManager.LoadScene("Scense0");
    }

    public void Slectmap1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Slectmap2()
    {
        SceneManager.LoadScene("ScenceHuyen");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
