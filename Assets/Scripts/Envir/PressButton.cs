using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    private bool pushAllow = false;
    private float playerCenterToFoot;
    

    private void Awake()
    {
        playerCenterToFoot = GameObject.FindWithTag("Player").GetComponent<Collider2D>().bounds.extents.y;
    }

    void Update()
    {
        if (pushAllow)
        {
            this.GetComponent<SpriteRenderer>().color=Color.red;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color=Color.white;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {   
        //object is aplayer and is on top of this
        if (collision.transform.tag == "Player")
        {
            if (collision.transform.position.y-playerCenterToFoot >= transform.position.y)
            {
                pushAllow = true;
            }
            else
            {
                pushAllow = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.transform.tag == "Player")
        {
            pushAllow = false;
        }
    }
    
    
}
