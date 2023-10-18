using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSaver : MonoBehaviour
{
    //number of seconds user is allowed to save
    [SerializeField] private int savingTimeLimit;
    #region Saved Lists
    private List<Vector3> movementList=new List<Vector3>();
    private List<Vector3> velocityList=new List<Vector3>();
    private List<bool> SpriteFliperList = new List<bool>();
    #endregion
    
    #region Internal

    private bool isRecording = false;
    private float startingTimeCounter;
    private float RecordingTimePeriod;


    #endregion

    #region External

    private Rigidbody2D playerRigidbody;
    private Transform playerTransform;
    private CloneSpawner cloneSpawnerSC;
    private SpriteRenderer spriteRenderer;
    private Walk WalkSC;

    #endregion

    
    void Awake()
    {
        playerTransform=GameObject.Find("Player").transform;
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        cloneSpawnerSC = FindObjectOfType<CloneSpawner>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        WalkSC = FindObjectOfType<Walk>();
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
            FlipDetection();
            //movementList.Add(playerTransform.position);
        }
    }

    private void FlipDetection()
    {
        if (WalkSC.TowardRightGiver)
        {
            SpriteFliperList.Add(true);
        }
        else
        {
            SpriteFliperList.Add(false);
        }
    }
    
    
    

    public List<Vector3> MovementListGiver => movementList;
    public List<Vector3> VelocityListGiver => velocityList;

    public List<bool> SpriteFliperListGiver => SpriteFliperList;
    public float RecordingTimePeriodGiver => RecordingTimePeriod;
    
    public bool EraseData
    {
        set
        {
            if (value)
            {
                movementList.Clear();
                velocityList.Clear();
                SpriteFliperList.Clear();
                isRecording = false;
            }
        }
    }
    


}
