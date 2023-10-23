using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lev1 : MonoBehaviour
{
    private int numberOfTimesOnButton = 0;
    private DialogueBox dialogueBoxSC;
    private void Awake()
    {
        dialogueBoxSC=GameObject.FindWithTag("Player").GetComponentInChildren<DialogueBox>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            numberOfTimesOnButton++;
        }

        if (numberOfTimesOnButton == 3)
        {
            PressQ();
        }
        
        if(numberOfTimesOnButton>=3){Invoke(nameof(PressQAgain), 5f);}
    }

    private void PressQ()
    {
        dialogueBoxSC.SetText("Press Q",3);
    }
    private void PressQAgain()
    {
        dialogueBoxSC.SetText("Press Q again",3);
    }
    
}
