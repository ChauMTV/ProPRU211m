using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Playgame()
    {
        SceneManager.LoadScene("Scense0");
    }
    public void Quitgame()
    {
        SceneManager.LoadScene("Scense0");
    }
}
