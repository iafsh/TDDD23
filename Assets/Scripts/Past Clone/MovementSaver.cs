using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSaver : MonoBehaviour
{
    private bool isRecording = false;
    //number of seconds user is allowed to save
    [SerializeField] private int savingTimeLimit;
    private float startingTimeCounter;
    private float RecordingTimePeriod;
    private List<Vector3> movementList=new List<Vector3>();
    private List<Vector3> velocityList=new List<Vector3>();
    private Rigidbody2D playerRigidbody;
    private Transform playerTransform;
    private CloneSpawner cloneSpawnerSC;
    
    void Awake()
    {
        playerTransform=GameObject.Find("Player").transform;
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        cloneSpawnerSC = FindObjectOfType<CloneSpawner>();
    }
    
    void Update()
    {
        print("isRecording:"+isRecording);
        if (cloneSpawnerSC.CloneisMoving)
        {
            isRecording = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            if (isRecording)
            {
                isRecording = false;
                RecordingTimePeriod = Time.time - startingTimeCounter;
                cloneSpawnerSC.GobackToStartPosition();
            }
            else
            {
                isRecording = true;
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
            RecordingTimePeriod = savingTimeLimit;
            cloneSpawnerSC.GobackToStartPosition();

        }
        else
        {
            movementList.Add(playerTransform.position);
            velocityList.Add(playerRigidbody.velocity);
            //movementList.Add(playerTransform.position);
        }
    }

    public List<Vector3> MovementListGiver => movementList;
    public List<Vector3> VelocityListGiver => velocityList;
    public float RecordingTimePeriodGiver => RecordingTimePeriod;
    
    public bool EraseData
    {
        set
        {
            if (value)
            {
                movementList.Clear();
                velocityList.Clear();
                isRecording = false;
            }
        }
    }


}
