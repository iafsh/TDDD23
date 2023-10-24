using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDestroyingOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
