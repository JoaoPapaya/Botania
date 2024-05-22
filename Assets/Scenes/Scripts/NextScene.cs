using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string NextSceneName;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoToNextScene();
    }

    private void GoToNextScene() 
    {
        SceneManager.LoadScene(this.NextSceneName);
    }

}
