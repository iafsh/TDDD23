using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class CloneSpawner : MonoBehaviour

{
    public bool MovementsSaved = false;
    private Stack<Vector3> movementStack;
    private Queue<Vector3> movementQueue;
    private MovementSaver movementSaverSC;
    private bool playFromStart = false;
    
    public bool CloneisMoving = false;


    private void Awake()
    {
        movementSaverSC = FindObjectOfType<MovementSaver>();
        disappearClone();
    }

    void Update()
    {
        
        if (MovementsSaved)
        {
            if (movementStack.Count != 0)
            {
                print("Here!!");
                
                //transform.position = Vector3.MoveTowards(transform.position, movementStack.Pop(), 100 * Time.deltaTime);
                this.transform.position = movementStack.Pop();
            }
            else
            {
                MovementsSaved = false;
                goToEndPosition();
            }
        }

    }
    
    

    public void GobackToStartPosition()
    {
        print("Gobacktostartposition has been called");
        this.transform.position = movementSaverSC.MovementListGiver[0];
        apearClone();
        goToEndPosition();
        //CloneisMoving = true;
        //MovementsSaved = true;
        //movementStack = new Stack<Vector3>(movementSaverSC.MovementListGiver);
        //print("MovementStack:"+string.Join(", ", movementStack));
        
        
    }

    IEnumerator MoveToEnd()
    {

        while (movementQueue.Count != 0)
        {

            this.transform.position = movementQueue.Dequeue();
            yield return new WaitForSeconds(.01f);

        }

        playFromStart = false;
        MoveEnds();
                
            
        
    }

    private void goToEndPosition()
    {
        print("Go to end position has been called");
        playFromStart = true;
        movementQueue = new Queue<Vector3>(movementSaverSC.MovementListGiver);
        StartCoroutine(MoveToEnd());


    }

    public void MoveEnds()
    {
        print("move ends has been called");
        disappearClone();
        CloneisMoving = false;
        movementSaverSC.EraseData = true;

    }

    private void apearClone()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void disappearClone()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled =false;
        
    }
}
