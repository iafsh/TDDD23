using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnLevelButtonClicked()
    {
        // Check if EventSystem.current is not null
        if (EventSystem.current != null)
        {
            // Getting the name of the clicked button
            string buttonName = EventSystem.current.currentSelectedGameObject.name;
            Debug.Log("Button Name: " + buttonName); // Print the retrieved button name

            int levelIndex;
            if (int.TryParse(buttonName, out levelIndex))
            {
                Debug.Log("Level " + levelIndex + " selected.");
                // You can load the selected level here
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogError("Invalid level index: " + buttonName);
            }
        }
        else
        {
            Debug.LogError("EventSystem.current is null. Please ensure there is an EventSystem object in your scene.");
        }
    }
}

