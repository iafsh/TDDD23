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
        private Renderer playeRenderer;
        private Rigidbody2D playerRigidbody;
        private Collider2D myCollider;
        private Walk WalkSC;
        //private float StartTime=0;

    #endregion

    private void Awake()
    {
        playerCollider=GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        playeRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        WalkSC = GameObject.FindObjectOfType<Walk>();
        destinationExtent = new Vector3(DestinationPortal.GetComponent<Collider2D>().bounds.extents.x, 0, 0);
        destinationPosition = DestinationPortal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (myCollider.bounds.Contains(playerCollider.bounds.min) &&
                myCollider.bounds.Contains(playerCollider.bounds.max))
            {
                GetComponent<SpriteRenderer>().color = Color.cyan;
                Mover();
                
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            //Waiter();

            
    }


    private void Mover()
    {
        if (playeRenderer.enabled)
        {
            
            //StartTime = Time.time;
            playeRenderer.enabled = false;
            playerRigidbody.velocity = Vector2.zero;
            if (WalkSC.TowardRightGiver)
            {
                playerTransform.position = destinationPosition + destinationExtent;
            }
            else
            {
                playerTransform.position = destinationPosition - destinationExtent;
            }
            playeRenderer.enabled = true;

        }

        // if (Waiter())
        // {
        //     playeRenderer.enabled = true;
        // }

    }

    // private bool Waiter()
    // {
    //     if (StartTime + TransportationTime < Time.time)
    //     {
    //         print(StartTime);
    //         print("aaaaaaaaaaaaaaaaaaaaaah");
    //         playeRenderer.enabled = true;
    //         return true;
    //         
    //     }
    //
    //     return false;

    //}
}
