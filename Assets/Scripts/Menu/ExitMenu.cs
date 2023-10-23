using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public void Resume()
    {
        FindObjectOfType<CanvasManager>().SetExitMenuActive(false);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
