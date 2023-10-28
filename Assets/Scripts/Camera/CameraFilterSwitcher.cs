using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraFilterSwitcher : MonoBehaviour
{
    [Tooltip("Drag your profiles here...")]
    public PostProcessProfile[] profiles;

    private CanvasManager canvasManager;
    private PostProcessVolume volume;
    private int currentProfileIndex = 0;

    private void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
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

    public void SwitchFilter(int index)
    {
        currentProfileIndex = index;
        volume.profile = profiles[currentProfileIndex];

        if (index == 1) canvasManager.SetCloneHUDActive(true);
        else canvasManager.SetCloneHUDActive(false);
    }

    public void SwitchFilter()
    {
        SwitchFilter((currentProfileIndex + 1) % profiles.Length);
    }
}
