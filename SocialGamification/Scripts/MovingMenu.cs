using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*

This script works with the spatial menu making it appear and dissapear based 
on the distance of the player. Also making it reapear if it SetActive(true) and the
player stears too far away from it. 

*/


public class MovingMenu : MonoBehaviour
{


    //Variables used in the script
    public GameObject movingMenu;
    public Camera playerCamera;
    private Vector3 playerPos;
    private Vector3 playerDirection; 
    private GameObject player;
    public GameObject canvas;

    public Image circleImage;
    public bool menuIsVisible = false;

    
    void Start()
    {
    //Look for the game objects
    player = GameObject.Find("Player");
    
    }

    // Update is called once per frame
    void Update()
    {
        //Move menu in front of player based on the player location.
        Vector3 playerPos = playerCamera.transform.position;
        Vector3 playerDirection = playerCamera.transform.forward;
        Quaternion playerRotation = playerCamera.transform.rotation;
        float spawnDistance = 5;
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
        
        //Move menu on Y-Axis only based on player orientation
        Vector3 lookPos = player.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
        float eulerY = lookRot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler (0, eulerY, 0);
        canvas.transform.rotation = rotation;

        float distance = Vector3.Distance(player.transform.position, canvas.transform.position);
        //Debug.Log(distance);


        //Toggle menu on and off base on key press.
        if(Input.GetKeyDown(KeyCode.Q)){

                //if menu is visible on key press turn it off
                if (menuIsVisible){
                    movingMenu.SetActive(false);
                    menuIsVisible = false;
                    circleImage.gameObject.SetActive(false);
                }

                //if menu is invisible on key press turn it on
                else{
                    canvas.transform.position = new Vector3(spawnPos.x, 8.5f, spawnPos.z);   
                    movingMenu.SetActive(true);
                    //Debug.Log(spawnPos);
                    menuIsVisible = true;
                }
        }
        //Make menu appear closer to player if player gets too far away from it.
        if (distance > 10){
            canvas.transform.position = spawnPos;
            //movingMenu.SetActive(true);   
        }
    }
}   

