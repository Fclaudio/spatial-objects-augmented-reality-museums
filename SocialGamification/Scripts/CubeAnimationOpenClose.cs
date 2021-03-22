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

public class CubeAnimationOpenClose : MonoBehaviour
{

    // Variables used in script. 
    private GameObject player;
    public Vector3 cubePosition;
    public Animator sideAAnimator;
    public Animator sideBAnimator;
    public Animator sideCAnimator;
    public Animator sideDAnimator;
    public Animator TopAnimator;
    private bool firstAnimationRunned = false;
    private bool secondAnimationRunned = false;
    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        player = GameObject.Find("Player");

        //Get the current object position
        cubePosition = this.transform.position;

        //Set all animators to false (disabled)
        TopAnimator.enabled = false;
        sideAAnimator.enabled = false;
        sideBAnimator.enabled = false;
        sideCAnimator.enabled = false;
        sideDAnimator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the distance between the object and the player
        float distance =  Vector3.Distance(player.transform.position,cubePosition);

        //Trigger animation based on the distance bewtween the object and the player
        if (distance < 9 && firstAnimationRunned == false){
            firstAnimationRunned = true;
            TopAnimator.enabled = true;
            TopAnimator.Play("LidOff");
            }


        if (distance < 4 && secondAnimationRunned == false){
        
            sideAAnimator.enabled = true;
            sideAAnimator.Play("SideADown");
            
            sideBAnimator.enabled = true;
            sideBAnimator.Play("SideBDown");

            sideCAnimator.enabled = true;
            sideCAnimator.Play("SideCDown");

            sideDAnimator.enabled = true;
            sideDAnimator.Play("SideDDown");

            secondAnimationRunned = true;
        }

        if (distance > 9 && firstAnimationRunned == true){
            TopAnimator.enabled = true;
            TopAnimator.SetFloat ("Direction", -1);
            TopAnimator.Play("LidOff 0", -1, 0f);
            firstAnimationRunned = false;
            }


        if (distance > 4 && secondAnimationRunned == true){
            secondAnimationRunned = false;
            
            sideCAnimator.SetFloat("Direction", -1);
            sideCAnimator.Play("SideCDown 0", -1, 0f);
            
            sideAAnimator.SetFloat("Direction", -1);
            sideAAnimator.Play("SideADown 0", -1, 0f);

            sideBAnimator.SetFloat("Direction", -1);
            sideBAnimator.Play("SideBDown 0", -1, 0f);

            sideDAnimator.SetFloat("Direction", -1);
            sideDAnimator.Play("SideDDown 0", -1, 0f);
            
            
        }

    }
}
