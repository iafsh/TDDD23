using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ButtonedElevator : MonoBehaviour
{
    [SerializeField] GameObject elevator;
    [SerializeField] float elevation = 5f;
    [SerializeField] float elevationSpeed = 5f;

    Vector2 startPosition = Vector2.zero;
    bool isElevating = false;

    void Start()
    {
        startPosition = elevator.transform.position;
    }

    void FixedUpdate()
    {
        if (isElevating)
        {
            if (elevator.transform.position.y < startPosition.y + elevation)
            {
                elevator.transform.position = new Vector2(
                    elevator.transform.position.x,
                    math.lerp(
                        startPosition.y + elevation,
                        elevator.transform.position.y,
                        math.exp2(-elevationSpeed * Time.fixedDeltaTime)
                    )
                );
            }
            else
            {
                elevator.transform.position = startPosition + new Vector2(0, elevation);
            }
        }
        else
        {
            if (elevator.transform.position.y > startPosition.y)
            {
                elevator.transform.position = new Vector2(
                    elevator.transform.position.x,
                    math.lerp(
                        startPosition.y,
                        elevator.transform.position.y,
                        math.exp2(-elevationSpeed * Time.fixedDeltaTime)
                    )
                );
            }
            else
            {
                elevator.transform.position = startPosition;
            }
        }
    }

    public void StartElevating()
    {
        isElevating = true;
    }

    public void StopElevating()
    {
        isElevating = false;
    }
}
