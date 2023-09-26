using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource levelPassSoundEffect;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Get the bounds of the player and the door
            Bounds playerBounds = collision.bounds;
            Bounds doorBounds = GetComponent<Collider2D>().bounds;

            // Check if the player is completely within the bounds of the door
            if (doorBounds.Contains(playerBounds.min) && doorBounds.Contains(playerBounds.max))
            {
                levelPassSoundEffect.Play();
                StartCoroutine(LoadNextSceneAfterAudio());
            }
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
        if (currentSceneIndex < sceneCount)
        {
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        }

        // Load the next scene
        SceneManager.LoadScene(nextSceneIndex);
    }


}
