using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // Get the index of the current active scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Get the total number of scenes in the build settings
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            // Calculate the index of the next scene
            int nextSceneIndex = (currentSceneIndex + 1) % sceneCount;

            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
