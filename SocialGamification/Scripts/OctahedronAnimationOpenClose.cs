using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

This script holds the information the cube spatial objects
Activates the animations and effects based on the proximity 
of the player and the object. 

Objects are not using the "Set Active" method given that
by setting them to "false" the objects stop tracking the 
distance between them and the player. 

*/

public class OctahedronAnimationOpenClose : MonoBehaviour
{

    //Variables used in the script.
    private GameObject player;
    public Vector3 octahedronPosition;
    public Animator sideABottomAnimator;
    public Animator sideBBottomAnimator;
    public Animator sideCBottomAnimator;
    
    public Animator sideDBottomAnimator;
    public Animator sideATopAnimator;
    public Animator sideBTopAnimator;
    
    public Animator sideCTopAnimator;
    public Animator sideDTopAnimator;

    private bool firstAnimationRunned = false;
    private bool secondAnimationRunned = false;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        player = GameObject.Find("Player");

        //Get the current object position
        octahedronPosition = this.transform.position;

        //Set all animators to false (disabled)
        sideABottomAnimator.enabled = false;
        sideBBottomAnimator.enabled = false;
        sideCBottomAnimator.enabled = false;
        sideDBottomAnimator.enabled = false;
        sideATopAnimator.enabled = false;
        sideBTopAnimator.enabled = false;
        sideCTopAnimator.enabled = false;
        sideDTopAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance =  Vector3.Distance(player.transform.position,octahedronPosition);
        
        //Debug.Log(distance);
        //Debug.Log(firstAnimationRunned);
        //Debug.Log(secondAnimationRunned);

        if (distance < 9 && firstAnimationRunned == false){
            firstAnimationRunned = true;

            sideABottomAnimator.enabled = true;
            sideABottomAnimator.Play("SIDE A BOTTOM HALF DOWN");
            
            sideBBottomAnimator.enabled = true;
            sideBBottomAnimator.Play("SIDE B BOTTOM HALF DOWN");

            sideCBottomAnimator.enabled = true;
            sideCBottomAnimator.Play("SIDE C BOTTOM HALF DOWN");

            sideDBottomAnimator.enabled = true;
            sideDBottomAnimator.Play("SIDE D BOTTOM HALF DOWN");
            
            sideATopAnimator.enabled = true;
            sideATopAnimator.Play("SIDE A TOP HALF DOWN");

            sideBTopAnimator.enabled = true;
            sideBTopAnimator.Play("SIDE B TOP HALF DOWN");

            sideCTopAnimator.enabled = true;
            sideCTopAnimator.Play("SIDE C TOP HALF DOWN");
            
            sideDTopAnimator.enabled = true;
            sideDTopAnimator.Play("SIDE D TOP HALF DOWN");
            
            }
            //player lid off animation

        if (distance < 4 && secondAnimationRunned == false){
        
            sideABottomAnimator.enabled = true;
            sideABottomAnimator.Play("SIDE A BOTTOM FULL DOWN");
            
            sideBBottomAnimator.enabled = true;
            sideBBottomAnimator.Play("SIDE B BOTTOM FULL DOWN");

            sideCBottomAnimator.enabled = true;
            sideCBottomAnimator.Play("SIDE C BOTTOM FULL DOWN");

            sideDBottomAnimator.enabled = true;
            sideDBottomAnimator.Play("SIDE D BOTTOM FULL DOWN");
            
            sideATopAnimator.enabled = true;
            sideATopAnimator.Play("SIDE A TOP FULL DOWN");

            sideBTopAnimator.enabled = true;
            sideBTopAnimator.Play("SIDE B TOP FULL DOWN");

            sideCTopAnimator.enabled = true;
            sideCTopAnimator.Play("SIDE C TOP FULL DOWN");
            
            sideDTopAnimator.enabled = true;
            sideDTopAnimator.Play("SIDE D TOP FULL DOWN");

            secondAnimationRunned = true;
        }

        if (distance > 9 && firstAnimationRunned == true){
            firstAnimationRunned = false;

            //sideCAnimator.enabled = true;
            sideABottomAnimator.SetFloat("Direction", -1);
            sideABottomAnimator.Play("SIDE A BOTTOM HALF DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideBBottomAnimator.SetFloat("Direction", -1);
            sideBBottomAnimator.Play("SIDE B BOTTOM HALF DOWN 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideCBottomAnimator.SetFloat("Direction", -1);
            sideCBottomAnimator.Play("SIDE C BOTTOM HALF DOWN 0", -1, 0f);

            sideDBottomAnimator.SetFloat("Direction", -1);
            sideDBottomAnimator.Play("SIDE D BOTTOM HALF DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideATopAnimator.SetFloat("Direction", -1);
            sideATopAnimator.Play("SIDE A TOP HALF DOWN 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideBTopAnimator.SetFloat("Direction", -1);
            sideBTopAnimator.Play("SIDE B TOP HALF DOWN 0", -1, 0f);

            sideCTopAnimator.SetFloat("Direction", -1);
            sideCTopAnimator.Play("SIDE C TOP HALF DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideDTopAnimator.SetFloat("Direction", -1);
            sideDTopAnimator.Play("SIDE D TOP HALF DOWN 0", -1, 0f);            
            }



        if (distance > 4 && secondAnimationRunned == true){
            secondAnimationRunned = false;
            
            //sideCAnimator.enabled = true;
            sideABottomAnimator.SetFloat("Direction", -1);
            sideABottomAnimator.Play("SIDE A BOTTOM FULL DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideBBottomAnimator.SetFloat("Direction", -1);
            sideBBottomAnimator.Play("SIDE B BOTTOM FULL DOWN 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideCBottomAnimator.SetFloat("Direction", -1);
            sideCBottomAnimator.Play("SIDE C BOTTOM FULL DOWN 0", -1, 0f);

            sideDBottomAnimator.SetFloat("Direction", -1);
            sideDBottomAnimator.Play("SIDE D BOTTOM FULL DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideATopAnimator.SetFloat("Direction", -1);
            sideATopAnimator.Play("SIDE A TOP FULL DOWN 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideBTopAnimator.SetFloat("Direction", -1);
            sideBTopAnimator.Play("SIDE B TOP FULL DOWN 0", -1, 0f);

            sideCTopAnimator.SetFloat("Direction", -1);
            sideCTopAnimator.Play("SIDE C TOP FULL DOWN 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideDTopAnimator.SetFloat("Direction", -1);
            sideDTopAnimator.Play("SIDE D TOP FULL DOWN 0", -1, 0f);  
        }

    }
}

