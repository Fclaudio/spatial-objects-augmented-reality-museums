using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script similar to the cubes and other spatial objects places spheres on space. 

public class SpherePlacement : MonoBehaviour
{
    //Variables used in script
    public  GameObject prefab;
    public GameObject placePrefab;
    private Vector3 playerPos;
    private Vector3 playerDirection;
    public Camera playerCamera;
    private GameObject previewSphere;
    public Material blueMaterial;
    public Material previewMaterial;
    bool buttonToggle = false;

    public static bool externalButtonToggle = false;

      // Update is called once per frame
      void Update()
    {  

        if(externalButtonToggle)
        {
            buttonToggle = true;
        }


        Vector3 playerPos = playerCamera.transform.position;
        Vector3 playerDirection = playerCamera.transform.forward;
        Quaternion playerRotation = playerCamera.transform.rotation;
        float spawnDistance = 2;
        Vector3 spawnPos = playerPos + playerDirection*spawnDistance;
        //Debug.Log(buttonToggle);

        if (buttonToggle)
        {
        
            if (previewSphere == null)
            {
                previewSphere = SpherePreview(spawnPos);   
            }
            previewSphere.transform.position = spawnPos;
        
            if (Cursor.visible == false){

                if (isClicked()){
                    if(Input.GetKeyDown(KeyCode.Mouse0)){
                        Destroy(previewSphere);
                        //prefab.GetComponent<Renderer>().material = blueMaterial;
                        GameObject messageCube = Instantiate(placePrefab,spawnPos, Quaternion.identity);
                        //Save cube current position
                            //currentPosition = spawnPos;
                        buttonToggle = false;
                        //Instantiate(prefab,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity);
                        }
                }
            }   


        } 
    }
    bool isClicked(){
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public void buttonIsPressed(){
       buttonToggle = !buttonToggle;
    }

    public GameObject SpherePreview(Vector3 spawnPos)
    {
        prefab.GetComponent<Renderer>().material = previewMaterial;
        GameObject previewCube = Instantiate(prefab,spawnPos, Quaternion.identity);
        return previewCube;
    }

}
