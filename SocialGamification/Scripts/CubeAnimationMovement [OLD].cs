using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimationMovement : MonoBehaviour
{

    //Script by: Diericx

    //Adjust this to change speed
    float speed = 2f;
    //Adjust this to change how high it goes
    float height = 0.001f;
 
void Update() {
        //Get the objects current position and put it in a variable so we can access it later with less code
        Vector3 position = this.transform.position;
        
        //Calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed);
        
        //Set the object's Y to the new calculated Y
        transform.position = new Vector3(position.x, position.y + (newY * height), position.z) ;
    }
}
