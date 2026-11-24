using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Serialization;
public class SceneChanger : MonoBehaviour
{
    
    public void SceneChange(string sceneName)
    { //this will load other scenes
            SceneManager.LoadSceneAsync($"{sceneName}", LoadSceneMode.Single);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
