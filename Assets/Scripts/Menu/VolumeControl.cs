using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the Slider UI component
    public GameObject bgmGameObject; // Reference to the GameObject containing the Audio Source for BGM

    private AudioSource bgmAudioSource; // Reference to the Audio Source component

    // Start is called before the first frame update
    void Start()
    {
        // Find the Audio Source component on the BGM GameObject
        bgmAudioSource = bgmGameObject.GetComponent<AudioSource>();

        // Initialize the slider's value to the current volume of the Audio Source
        volumeSlider.value = bgmAudioSource.volume;

        // Add a listener to call our VolumeController function whenever the slider changes
        volumeSlider.onValueChanged.AddListener(delegate { VolumeController(); });
    }

    // This function will be called when the slider value changes
    public void VolumeController()
    {
        // Set the volume of the Audio Source to the value of the slider
        bgmAudioSource.volume = volumeSlider.value;

    }
}