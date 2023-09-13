using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private float Speed;

    private bool allowedToMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        allowedToMove = (!this.GetComponent<Jump>().OnAirGiver) && !Input.GetKey(KeyCode.Space);
        if (allowedToMove)
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.right * Speed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.left * Speed;
            }
        }
    }
}
