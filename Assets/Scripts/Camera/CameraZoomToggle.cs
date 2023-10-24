using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomToggle : MonoBehaviour
{
    [SerializeField] private float zoomedOutSize = 5f;
    [SerializeField] private float zoomSpeed = 6f;

    private float defaultSize;
    private Camera mainCamera;
    private bool isZoomedOut = false;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();

        defaultSize = mainCamera.orthographicSize;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleZoom();
        }
    }

    private void ToggleZoom()
    {
        if (isZoomedOut)
        {
            StartCoroutine(Zoom(defaultSize));
        }
        else
        {
            StartCoroutine(Zoom(defaultSize + zoomedOutSize));
        }
        isZoomedOut = !isZoomedOut;
    }

    private IEnumerator Zoom(float targetZoom)
    {
        float startZoom = mainCamera.orthographicSize;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Lerp(startZoom, targetZoom, t);
            yield return null;
        }
    }
}