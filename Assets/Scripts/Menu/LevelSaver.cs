using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaver : MonoBehaviour
{
    
    public void SavePrefs()
    {
        PlayerPrefs.SetInt("Volume", 50);
        PlayerPrefs.Save();
    }
 
    public void LoadPrefs()
    {
        int volume = PlayerPrefs.GetInt("Volume", 0); 
    }
}
