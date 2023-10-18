using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraFilterSwitcher : MonoBehaviour
{
    public PostProcessProfile[] profiles; // Assign your different profiles here
    private PostProcessVolume volume;
    private int currentProfileIndex = 0;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        if (profiles.Length > 0)
        {
            SetProfile(currentProfileIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchFilter();
        }
    }

    private void SwitchFilter()
    {
        // Increment the index and loop around if necessary
        currentProfileIndex = (currentProfileIndex + 1) % profiles.Length;
        SetProfile(currentProfileIndex);
    }

    private void SetProfile(int index)
    {
        // Disable all effects in the current profile
        foreach (var effect in volume.profile.settings)
        {
            effect.active = false;
        }

        // Set the volume's profile to the new one
        volume.profile = profiles[index];

        // Enable all effects in the new profile
        foreach (var effect in volume.profile.settings)
        {
            effect.active = true;
        }

        Debug.Log("Switched to profile: " + index);
    }
}