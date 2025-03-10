using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ChangeScene(GameObject button)
    {
        string nextScene = button.tag;
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(nextScene);
        }
        Debug.Log(nextScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseScene");
    }
}
