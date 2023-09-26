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
        print(playerCenterToFoot);
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
        print("clone is on me");
        //object is player or clone and is on top of this
        if (collision.gameObject.layer == 6)
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
        
        if (other.gameObject.layer==6)
        {
            pushAllow = false;
        }
    }
    
    
}
