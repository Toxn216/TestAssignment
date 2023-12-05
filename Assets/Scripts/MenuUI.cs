using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    private static string MAINSCENE = "MainScene";
    [SerializeField] private Button restart;
    [SerializeField] private Button Exit;
 
    public void RestartLevel()
    {
        SceneManager.LoadScene(MAINSCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
