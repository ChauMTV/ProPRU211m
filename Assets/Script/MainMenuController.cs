using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
<<<<<<< HEAD
{
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene("Scense0");
=======

{
    

    public void Playgame()
    {
        SceneManager.LoadScene("LevelSelect");
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    }
    public void Quitgame()
    {
        SceneManager.LoadScene("Scense0");
    }
<<<<<<< HEAD
=======

    public void Slectmap()
    {
        SceneManager.LoadScene("Scense0");
    }

    public void Slectmap1()
    {
        SceneManager.LoadScene("SceneTung");
    }

    public void Slectmap2()
    {
        SceneManager.LoadScene("ScenceHuyen");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
}
