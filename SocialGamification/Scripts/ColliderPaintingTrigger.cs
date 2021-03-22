using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is used to activate the colliders near the paintings
//in order to make the spatial objects dissapear, when the visitor
//spends too much time standing still.
public class ColliderPaintingTrigger : MonoBehaviour
{

public static bool IsNearPainting;

    //When the player enters the collider area
    bool OnTriggerEnter(Collider other)
    {
        Debug.Log ("Object is near painting");
        return IsNearPainting = true;
    }

    //When player leaves the collider area. 
    bool OnTriggerExit(Collider other)
    {
        Debug.Log ("Object is not near painting");
        return IsNearPainting = false;
    }

}
