using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script manages the transparency and visual aspect of the object. 
All this is based on the proximity of the player. 
*/

public class OctahedronProximityForAnimatedOctahedron : MonoBehaviour
{

    //Variables used in script
    private GameObject player;
    public GameObject SideABottom;
    public GameObject SideBBottom;
    public GameObject SideCBottom;
    public GameObject SideDBottom;
    public GameObject SideATop;    
    public GameObject SideBTop;
    public GameObject SideCTop;    
    public GameObject SideDTop;
    private Vector3 diamondPosition;
    public GameObject messageCanvas;
    public GameObject thumbsUpCanvas;
    public GameObject diamondObjects;
    private float timer  = 0.0f; 
    private float timerLimit = 5.0f;

    bool timerRanOut;
//=======================================================

 private float noMovementThreshold = 0.0001f;
 private const int noMovementFrames = 3;
 Vector3[] previousLocations = new Vector3[noMovementFrames];
 private bool isMoving;

    //public Material cubeMaterial;
    // Start is called before the first frame update
    void Start(){
        //Find the player
        player = GameObject.Find("Player");
        //Gathe cube position
        diamondPosition = this.transform.position;
        timerRanOut = false;
        
    }

    // Update is called once per frame
    void Update(){
        
        //Calculate the distance between the ball player and the pick up objects
		float distance =  Vector3.Distance(player.transform.position,diamondPosition);

        //float trasparency = 
        float transparency = scaleNumber(2,11,0,1,distance);
        
        if (transparency < 0){
            transparency = 0;
        }

        else if (transparency > 1){
            transparency = 1;
        }
        //New color variable;
        Color newColor = new Color(255.0f,255.0f,0.0f,transparency);
    
        //Debug.Log(transparency);
        
        //Apply new color to cube components
        SideABottom.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideBBottom.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideCBottom.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideDBottom.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideATop.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideBTop.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideCTop.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        SideDTop.GetComponent<Renderer>().material.SetColor("_UnlitColor", newColor);
        
        //Old Methodology [OBSOLOTE]
        //cubeMaterial.color = new Color(0.0f,0.0f,255.0f,transparency);

        //Turn the cubes on and off after getting away from it
        if (distance > 12){
            //Hide the cube from sight
            DeactivateteBox();
        }
        else{
            //Show the cube from sight
            ActivateBox();

        }
    
        if (distance > 6){
            //Hide the cube from sight
            DeactivateteMessageAndLikes();
        }
        else{
            //Show the cube from sight
            ActivateteMessageAndLikes();
        }



    //===================================================================
    
     //Store the newest vector at the end of the list of vectors

     if(ColliderPaintingTrigger.IsNearPainting)
     {

        for(int i = 0; i < previousLocations.Length - 1; i++)
        {
            previousLocations[i] = previousLocations[i+1];
        }
        previousLocations[previousLocations.Length - 1] = player.transform.position;

        //Check the distances between the points in your previous locations
        //If for the past several updates, there are no movements smaller than the threshold,
        //you can most likely assume that the object is not moving
        for(int i = 0; i < previousLocations.Length - 1; i++)
        {
            Debug.Log(Vector3.Distance(previousLocations[i], previousLocations[i + 1]));
            if(Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
            {
                //The minimum movement has been detected between frames
                isMoving = !true;
                break;
            }
        }
     }
    else
    {
        isMoving = true;
    }

    //Debug.Log(isMoving);

    if (isMoving == false){
        timer += Time.deltaTime;
    }
    else{
        timer = 0.0f;
    }
    if (timer > timerLimit){
        DeactivatetePrefab();
        timerRanOut = true;
    }
    if(ColliderPaintingTrigger.IsNearPainting == false && timerRanOut){
        ActivatetePrefab();
        timerRanOut = false;
    }


}
float scaleNumber(float minInput, float maxInput, float minOutput, float maxOutput, float value){
     float result = (value - minInput) / ( maxInput - minInput) * (maxOutput - minOutput) + minOutput;
     return result;
}

void DeactivatetePrefab(){
    messageCanvas.SetActive(false);
    thumbsUpCanvas.SetActive(false);
    diamondObjects.SetActive(false);
}

void ActivatetePrefab(){
    messageCanvas.SetActive(true);
    thumbsUpCanvas.SetActive(true);
    diamondObjects.SetActive(true);
}


void DeactivateteMessageAndLikes(){
    messageCanvas.SetActive(false);
    thumbsUpCanvas.SetActive(false);
}

void ActivateteMessageAndLikes(){
    messageCanvas.SetActive(true);
    thumbsUpCanvas.SetActive(true);
}


void ActivateBox(){
        SideABottom.GetComponent<Renderer>().enabled = true;
        SideBBottom.GetComponent<Renderer>().enabled = true;
        SideCBottom.GetComponent<Renderer>().enabled = true;
        SideDBottom.GetComponent<Renderer>().enabled = true;
        SideATop.GetComponent<Renderer>().enabled = true;
        SideBTop.GetComponent<Renderer>().enabled = true;
        SideCTop.GetComponent<Renderer>().enabled = true;
        SideDTop.GetComponent<Renderer>().enabled = true;
}

void DeactivateteBox(){
        SideABottom.GetComponent<Renderer>().enabled = false;
        SideBBottom.GetComponent<Renderer>().enabled = false;
        SideCBottom.GetComponent<Renderer>().enabled = false;
        SideDBottom.GetComponent<Renderer>().enabled = false;
        SideATop.GetComponent<Renderer>().enabled = false;
        SideBTop.GetComponent<Renderer>().enabled = false;
        SideCTop.GetComponent<Renderer>().enabled = false;
        SideDTop.GetComponent<Renderer>().enabled = false;
}


}