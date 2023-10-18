using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Collider2D playerCollider;
    private Collider2D myCollider;
    private LevelSaver levelSaverSC;
    private void Awake()
    {
        playerCollider=GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        myCollider = GetComponent<Collider2D>();
        levelSaverSC = FindObjectOfType<LevelSaver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.bounds.Contains(playerCollider.bounds.min) &&
            myCollider.bounds.Contains(playerCollider.bounds.max))
        {
            GetComponent<SpriteRenderer>().color=Color.cyan;
        }
        else
        {
            GetComponent<SpriteRenderer>().color=Color.yellow;
        }
    }
}
