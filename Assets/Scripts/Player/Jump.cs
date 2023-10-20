using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private AudioSource jumpSoundEffect;

    private bool OnAir = true;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !OnAir)
        {
            jumpSoundEffect.Play();
            this.GetComponent<Rigidbody2D>().AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
        }

        if (GetComponent<Rigidbody2D>().velocity.y > jumpPower)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x,
                jumpPower
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.gameObject.layer == 7 || col.transform.gameObject.layer == 6)
        {
            OnAir = false;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        //environment layer or clone
        if (collision.transform.gameObject.layer == 7 || collision.transform.gameObject.layer == 6)
        {
            OnAir = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.gameObject.layer == 7 || other.transform.gameObject.layer == 6)
        {
            OnAir = true;
        }
    }

    public bool OnAirGiver
    {
        get
        {
            return OnAir;
        }
    }

}
