using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private AudioSource jumpSoundEffect;

    private bool OnAir = true;


    public bool OnAirGiver
    {
        get
        {
            return OnAir;
        }
    }

    void Update()
    {
        GroundDetection();

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !OnAir)
        {
            jumpSoundEffect.Play();
            GetComponent<Rigidbody2D>().AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
        }

        if (GetComponent<Rigidbody2D>().velocity.y > jumpPower)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(
                GetComponent<Rigidbody2D>().velocity.x,
                jumpPower
            );
        }
    }

    private void FixedUpdate()
    {

    }

    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.transform.gameObject.layer == 7 || col.transform.gameObject.layer == 6)
    //     {
    //         OnAir = false;
    //     }
    // }
    //
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.transform.gameObject.layer == 7 || other.transform.gameObject.layer == 6)
    //     {
    //         OnAir = true;
    //     }
    // }
    //
    //
    // private void OnCollisionStay2D(Collision2D collision)
    // {
    //     //environment layer or clone
    //     if (collision.transform.gameObject.layer == 7 || collision.transform.gameObject.layer == 6)
    //     {
    //         OnAir = false;
    //     }
    // }

    private void GroundDetection()
    {
        Collider2D coll = GetComponent<Collider2D>();
        List<RaycastHit2D> hits = Physics2D.BoxCastAll(
            coll.bounds.center,
            coll.bounds.size,
            0f,
            Vector2.down,
            1f
        ).ToList();

        if (
            hits.Count > 0 &&
            (
                hits.FindAll(hit => hit.transform.gameObject.layer == 7).Count > 0 ||
                hits.FindAll(hit => hit.transform.CompareTag("Clone")).Count > 0
            )
        )
        {
            OnAir = false;
        }
        else
        {
            OnAir = true;
        }

        Debug.DrawRay(transform.position, Vector2.down * 1);
    }
}
