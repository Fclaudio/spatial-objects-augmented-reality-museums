using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

This script manages the camera movement of the player. 

*/ 


public class PlayerCameraController : MonoBehaviour
{

    //Variables used in script
    public float cameraSensitivity;
    public float smoothing;
    public GameObject player;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPosition; 
    private float xRotation;


    //Start is called before the first frame update
    void Start(){
        //Based on the hierarchy que game object is being called
        player = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update(){
        
        if(Cursor.visible == false){
           RotateCameraAdvance(); 
        
        }
    }
    void RotateCameraAdvance(){
        
        //Same distance apart relatively
        Vector2 inputValues = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        //Scaling out input down
        inputValues = Vector2.Scale(inputValues, new Vector2(cameraSensitivity * smoothing, cameraSensitivity *smoothing));
       
        //Smoothing the movement of the camera
        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, inputValues.x, 1f/smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, inputValues.y, 1f/smoothing);
        
        //Taking our current Vector2 and adding on to it.
        currentLookingPosition += smoothedVelocity;

        //Rotation of the camera
        xRotation = -currentLookingPosition.y;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        //Player spins around the Y Axis
        player.transform.localRotation =  Quaternion.AngleAxis(currentLookingPosition.x, player.transform.up);
    }
}