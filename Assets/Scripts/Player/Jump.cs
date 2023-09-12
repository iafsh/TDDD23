using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower=20;
    private float jumpLength=10;
    private bool allowedToJump = true;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && allowedToJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(jumpPower*Vector2.up,ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // RaycastHit hitGround;
        // Physics.Raycast(transform.position, Vector3.down,out hitGround,jumpLength);
        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * jumpLength, Color.yellow);
        // print(hitGround.collider);
        // //means they are standing on sth
        // if (hitGround.collider != null)
        // {
        //     allowedToJump = true;
        //     
        // }
        // else
        // {
        //     allowedToJump = false;
        // }
        
        RaycastHit2D hitData = Physics2D.Raycast
            //ignors the player collider
            (transform.position, Vector2.down, jumpLength,6);

        Debug.DrawRay(transform.position, Vector3.down * jumpLength, Color.magenta);
        print(hitData.collider);
    }
}
