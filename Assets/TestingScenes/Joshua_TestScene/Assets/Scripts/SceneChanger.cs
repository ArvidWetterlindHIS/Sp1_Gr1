using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Serialization;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int Scene;
    public void SceneChange()
    { //this will load other scene
        if (Scene == 0)
        {
            SceneManager.LoadSceneAsync("OtherScene", LoadSceneMode.Single);
            Scene = 1;
        }
        else
        {
            SceneManager.LoadSceneAsync("Joshua_TestScene", LoadSceneMode.Single);
            Scene = 0;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
