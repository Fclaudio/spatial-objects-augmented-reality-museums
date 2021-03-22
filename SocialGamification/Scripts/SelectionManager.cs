using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This script sets the crosshair for the player in the middle of the screen
Attaching a raycaster to that point. 
Making sure where the player is looking is what they are selecting. 
*/
public class SelectionManager : MonoBehaviour
{
    //Variables used in this script. 
    public Image crosshair;

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            var selection = hit.transform;
        }
    }
}
