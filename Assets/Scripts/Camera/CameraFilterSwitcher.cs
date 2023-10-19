using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraFilterSwitcher : MonoBehaviour
{
    public PostProcessProfile[] profiles; // Drag your profiles here in the Inspector
    private PostProcessVolume volume;
    private int currentProfileIndex = 0;

    private void Start()
    {
        volume = GetComponent<PostProcessVolume>();
        if (profiles.Length > 0)
        {
            volume.profile = profiles[currentProfileIndex];
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
        currentProfileIndex = (currentProfileIndex + 1) % profiles.Length;
        volume.profile = profiles[currentProfileIndex];
    }
}
