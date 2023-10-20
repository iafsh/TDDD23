using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject DestinationPortal;
    //[SerializeField] private int TransportationTime;

    #region Internal Variables
    private Vector3 destinationPosition;
    private Vector3 destinationExtent;
    private Collider2D playerCollider;
    private Transform playerTransform;
    private Renderer playerRenderer;
    private Rigidbody2D playerRigidbody;
    private Collider2D myCollider;
    private Walk WalkSC;
    //private float StartTime=0;

    #endregion

    private void Awake()
    {
        playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        playerRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        WalkSC = GameObject.FindObjectOfType<Walk>();
        destinationExtent = new Vector3(DestinationPortal.GetComponent<Collider2D>().bounds.extents.x, 0, 0);
        destinationPosition = DestinationPortal.transform.position;
    }

    private void Move() {
        if (WalkSC.TowardRightGiver)
        {
            playerTransform.position = destinationPosition + destinationExtent;
        }
        else
        {
            playerTransform.position = destinationPosition - destinationExtent;
        }

        playerRenderer.enabled = true;
        playerTransform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerTransform.GetComponent<Animator>().Play("unteleport");
    }

    private void Teleport()
    {
        playerRigidbody.velocity = Vector2.zero;
        playerTransform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        playerTransform.GetComponent<Animator>().Play("teleport");
        Invoke(nameof(Hide), 0.25f);
        Invoke(nameof(Move), 1f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player is here");
            if (myCollider.bounds.Contains(playerCollider.bounds.min) &&
                myCollider.bounds.Contains(playerCollider.bounds.max))
            {
                Teleport();
            }
        }
    }

    private void Hide() {
        playerRenderer.enabled = false;
    }
}
