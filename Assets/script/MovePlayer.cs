using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{

    private PlayerInputManger Inputs;
    private CharacterController Controller;

    [SerializeField] public AudioSource AudioSource;

    [SerializeField] public AudioClip [] AudioGround;

    [SerializeField] private float MoveSpeed =5f;
    [SerializeField] private float RunSpeed = 10f;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool isGround; 

    [SerializeField] private WAckSound walk;
    [SerializeField] private bool currentState = true;
    [SerializeField] private bool storeCurrentState ;
    // Start is called before the first frame update
    void Start()
    {
        Inputs = GetComponent<PlayerInputManger>();
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = transform.right * Inputs.move.x + transform.forward*Inputs.move.y;
        if(Input.GetKey(KeyCode.LeftShift) && !Move.Equals(Vector3.zero))
        {
           // Debug.Log("run");
            Controller.Move(Move*Time.deltaTime*RunSpeed);
            
            
        }  
        else if(!Move.Equals(Vector3.zero))
        {
           // Debug.Log("walk");
            Controller.Move(Move*Time.deltaTime*MoveSpeed);
            if(currentState != (storeCurrentState = walk.Walk()))
            {
                currentState = storeCurrentState;
                playWalkSound();
            }
        }
        SetGravity();
        
    }


    void SetGravity()
    {
        isGround = Physics.CheckSphere(GroundCheck.position,0.4f,GroundLayer);
        if(isGround && velocity.y < 0f)
        {
           velocity.y = -2f;; 
        }
       // Debug.Log(gravity);
        velocity.y -= gravity*Time.deltaTime; 
       // Debug.Log(velocity.y);
        Controller.Move(velocity*Time.deltaTime);
    }
    void playWalkSound()
   {
     //Debug.Log("run sound");
        int len = Random.Range(0,AudioGround.Length);
        AudioSource.PlayOneShot(AudioGround[len]);
   }
}
