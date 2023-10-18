using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    [SerializeField] UnityEvent EmitPress;
    [SerializeField] UnityEvent EmitUnpress;

    private float playerCenterToFoot;


    private void Awake()
    {
        playerCenterToFoot = GameObject.FindWithTag("Player").GetComponent<Collider2D>().bounds.extents.y;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //object is player or clone and is on top of this
        if (collision.gameObject.layer == 6)
        {
            if (collision.transform.position.y - playerCenterToFoot >= transform.position.y)
            {
                EmitPress?.Invoke();
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                EmitUnpress?.Invoke();
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            EmitUnpress?.Invoke();
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
