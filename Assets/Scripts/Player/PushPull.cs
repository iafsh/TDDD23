using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    #region Internal
    private bool playerTouch=false;
    [SerializeField] float pushSpeed;
    #endregion

    #region External

    private Vector2 playerDirection;

    #endregion

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && playerTouch)
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = playerDirection * pushSpeed;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            playerTouch = true;
        }
        
    }
}
