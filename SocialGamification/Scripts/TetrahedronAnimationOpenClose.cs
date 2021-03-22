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

public class TetrahedronAnimationOpenClose : MonoBehaviour
{
    private GameObject player;
    public Vector3 tetrahedonPosition;
    public Animator sideAAnimator;
    public Animator sideBAnimator;
    public Animator sideCAnimator;

    private bool firstAnimationRunned = false;
    private bool secondAnimationRunned = false;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        player = GameObject.Find("Player");

        //Get the current object position
        tetrahedonPosition = this.transform.position;

        //Set all animators to false (disabled)
        sideAAnimator.enabled = false;
        sideBAnimator.enabled = false;
        sideCAnimator.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Get the distance between the object and the player
        float distance =  Vector3.Distance(player.transform.position,tetrahedonPosition);
        
        //Trigger animation based on the distance bewtween the object and the player
        if (distance < 9 && firstAnimationRunned == false){
            firstAnimationRunned = true;

            sideAAnimator.enabled = true;
            sideAAnimator.Play("sideAOpen");
            
            sideBAnimator.enabled = true;
            sideBAnimator.Play("sideBOpen");

            sideCAnimator.enabled = true;
            sideCAnimator.Play("sideCOpen");
            }
            //player lid off animation

        if (distance < 4 && secondAnimationRunned == false){
        
            sideAAnimator.enabled = true;
            sideAAnimator.Play("sideAFullDown");
            
            sideBAnimator.enabled = true;
            sideBAnimator.Play("sideBFullDown");

            sideCAnimator.enabled = true;
            sideCAnimator.Play("sideCFullDown");

            secondAnimationRunned = true;
        }

        if (distance > 9 && firstAnimationRunned == true){
            firstAnimationRunned = false;

            //sideCAnimator.enabled = true;
            sideCAnimator.SetFloat("Direction", -1);
            sideCAnimator.Play("sideCOpen 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideAAnimator.SetFloat("Direction", -1);
            sideAAnimator.Play("sideAOpen 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideBAnimator.SetFloat("Direction", -1);
            sideBAnimator.Play("sideBOpen 0", -1, 0f);
            
            }



        if (distance > 4 && secondAnimationRunned == true){
            secondAnimationRunned = false;
            
            //sideCAnimator.enabled = true;
            sideCAnimator.SetFloat("Direction", -1);
            sideCAnimator.Play("sideCFullDown 0", -1, 0f);
            
            //sideAAnimator.enabled = true;
            sideAAnimator.SetFloat("Direction", -1);
            sideAAnimator.Play("sideAFullDown 0", -1, 0f);
            
            //sideBAnimator.enabled = true;
            sideBAnimator.SetFloat("Direction", -1);
            sideBAnimator.Play("sideBFullDown 0", -1, 0f);
            
        }

    }
}
