using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource levelPassSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            levelPassSoundEffect.Play();

            StartCoroutine(LoadNextSceneAfterAudio());
        }
    }

    private IEnumerator LoadNextSceneAfterAudio()
    {
        // Wait for the audio to finish playing
        yield return new WaitForSeconds(levelPassSoundEffect.clip.length);

        // Get the index of the current active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Get the total number of scenes in the build settings
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // Calculate the index of the next scene
        int nextSceneIndex = (currentSceneIndex + 1) % sceneCount;

        // Update the unlocked level in PlayerPrefs
        if (nextSceneIndex < sceneCount)
        {
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        }

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }


}
