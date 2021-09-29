using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static void QuitStartMenu()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Start");
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
    public static void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("_Scene_0");
    }

    public static void FinishGame()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Finish");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) QuitStartMenu();
    }
}
