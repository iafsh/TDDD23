using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev0 : MonoBehaviour
{
    void Start()
    {
        GameObject.FindWithTag("Player").transform.position = new Vector3(-47, 3, 0);
    }
}
