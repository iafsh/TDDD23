using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioEnd : MonoBehaviour
{
    private AudioSource welcomeAudioSource;

    void Start()
    {
        GameObject welcomeAudioObject = GameObject.Find("welcomeAudio");
        if (welcomeAudioObject != null)
        {
            welcomeAudioSource = welcomeAudioObject.GetComponent<AudioSource>();
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (welcomeAudioSource != null && welcomeAudioSource.isPlaying)
        {
            welcomeAudioSource.Stop();
        }
    }
}
