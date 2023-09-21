using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSaver : MonoBehaviour
{
    private bool isRecording = false;
    //number of seconds user is allowed to save
    [SerializeField] private int savingTimeLimit;
    private float startingTimeCounter;
    private Stack<Vector3> movementStack;
    private Transform playerTransform;
    
    void Awake()
    {
        playerTransform=GameObject.Find("Player").transform;
    }
    
    void Update()
    {
        //print(movementStack);
        if (Input.GetKeyDown(KeyCode.C))
        {
            print("pushed");
            if (isRecording)
            {
                isRecording = false;
                print(movementStack);
            }
            else
            {
                startingTimeCounter=Time.time;
            }
        }

        if (isRecording)
        {
            Saver();
        }
    }

    private void Saver()
    {
        if (Time.time - startingTimeCounter > savingTimeLimit)
        {
            isRecording = false;
            //print(movementStack);
        }
        movementStack.Push(playerTransform.position);
    }
}
