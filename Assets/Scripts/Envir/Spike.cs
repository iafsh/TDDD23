using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [SerializeField] bool retracted = false;
    [SerializeField] float retractSpeed = 10f;

    Vector2 startPosition = Vector2.zero;

    void Start()
    {
        startPosition = transform.position;

        if (retracted)
        {
            transform.position = new Vector2(startPosition.x, startPosition.y - 1);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (retracted)
        {
            transform.position = new Vector2(
                transform.position.x,
                math.lerp(
                    startPosition.y - 1,
                    transform.position.y,
                    math.exp2(-retractSpeed * Time.fixedDeltaTime)
                )
            );
        }
        else
        {
            transform.position = new Vector2(
                transform.position.x,
                math.lerp(
                    startPosition.y,
                    transform.position.y,
                    math.exp2(-retractSpeed * Time.fixedDeltaTime)
                )
            );
        }
    }

    public void Activate()
    {
        retracted = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Deactivate()
    {
        retracted = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
