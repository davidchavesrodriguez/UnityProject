using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeScene(GameObject button)
    {
        string nextScene = button.tag;
        {
            SceneManager.LoadScene(nextScene);
        }
        Debug.Log(nextScene);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
