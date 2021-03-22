using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

This script works with the messages inside the objects.

Managin their orientation and the different message types that
can be stored within the object. 

*/

public class TetrahedronMessage : MonoBehaviour
{
    //Variables used in script
   private GameObject player;
   public GameObject messageObject;
   public GameObject canvas;
   public GameObject thumbUpCanvas;

   public Camera playerCamera;
   bool isVisible;
   //Set visibility distance
   const float visibilityDistance = 4.0f;

   // Start is called before the first frame update
    void Start()
    {
        //Look for the game objects
        player = GameObject.Find("Player");
        playerCamera = Camera.main;
        //Hide canvas by deafault
        isVisible = false;
        canvas.SetActive(isVisible);
        thumbUpCanvas.SetActive(isVisible);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculae distance between cube and player
        float distance = Vector3.Distance(player.transform.position, messageObject.transform.position);

        //Make text face the user
        canvas.transform.LookAt(2 * canvas.transform.position - player.transform.position);
        thumbUpCanvas.transform.LookAt(2 * canvas.transform.position - player.transform.position);

    }
}
