using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void LoadGame()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}