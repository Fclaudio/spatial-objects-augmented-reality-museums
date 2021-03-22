using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProximity : MonoBehaviour
{

    private GameObject player;
    private GameObject cube;
    public Vector3 cubePosition;
    // Start is called before the first frame update
    void Start(){
        //Find the player
        player = GameObject.Find("Player");
        //Gathe cube position
        cubePosition = this.transform.position;
    }

    // Update is called once per frame
    void Update(){
        
        //Calculate the distance between the ball player and the pick up objects
		float distance =  Vector3.Distance(player.transform.position,cubePosition);
        //Debug.Log(distance);
        
        if (distance > 12){
            //Hide the cube from sight
            this.GetComponent<Renderer>().enabled = false;
        }
        else{
            //Show the cube from sight
            this.GetComponent<Renderer>().enabled = true;
        }
    }
}

