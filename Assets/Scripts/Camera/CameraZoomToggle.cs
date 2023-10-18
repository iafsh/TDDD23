using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomToggle : MonoBehaviour
{
    [SerializeField] private float defaultSize = 6f;
    [SerializeField] private float zoomedOutSize = 10f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 2, 0);
    [SerializeField] private AudioClip zoomingSoundEffect; // New field for the sound effect

    private Camera mainCamera;
    private AudioSource audioSource; // To play the sound effect
    private bool isZoomedOut = false;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component
        audioSource.clip = zoomingSoundEffect; // Assign the sound effect to the AudioSource
        audioSource.loop = false; // Ensure the sound doesn't loop

        if (playerTransform == null)
        {
            playerTransform = GameObject.Find("Player").transform;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleZoom();
        }
    }

    private void LateUpdate()
    {
        mainCamera.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, mainCamera.transform.position.z);
    }

    private void ToggleZoom()
    {
        if (isZoomedOut)
        {
            StartCoroutine(Zoom(defaultSize));
        }
        else
        {
            StartCoroutine(Zoom(zoomedOutSize));
        }
        isZoomedOut = !isZoomedOut;
    }

    private IEnumerator Zoom(float targetZoom)
    {
        float startZoom = mainCamera.orthographicSize;
        float t = 0;

        audioSource.Play(); // Play the zooming sound effect

        while (t < 1)
        {
            t += Time.deltaTime * zoomSpeed;
            mainCamera.orthographicSize = Mathf.Lerp(startZoom, targetZoom, t);
            mainCamera.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, mainCamera.transform.position.z);
            yield return null;
        }

        audioSource.Stop(); // Stop the zooming sound effect
    }
}