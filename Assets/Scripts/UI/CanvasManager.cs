using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject exitMenu;
    [SerializeField] GameObject cloneHUD;

    private float timeScale = 1f;

    void Start()
    {
        timeScale = Time.timeScale;

        SetExitMenuActive(false);
        SetCloneHUDActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetExitMenuActive(!exitMenu.activeInHierarchy);
        }
    }

    public void SetExitMenuActive(bool value)
    {
        Time.timeScale = value ? 0f : timeScale;

        exitMenu.SetActive(value);
    }

    public void SetCloneHUDActive(bool value)
    {
        cloneHUD.SetActive(value);
    }
}
