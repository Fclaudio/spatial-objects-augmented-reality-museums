using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using UnityEditor;

/*

This script manages the aspect of placing the objects in space
and generating a spatial preview before the object is placed. 

*/

public class Placing_Object : MonoBehaviour
{

    //Variables used in script
    public  GameObject prefab;
    public GameObject placePrefab;
    private Vector3 playerPos;
    private Vector3 playerDirection;
    public Camera playerCamera;
    private GameObject previewCube;
    public Material blueMaterial;
    public Material previewMaterial;
    bool buttonToggle = false;
    public static bool externalButtonToggle = false;

    //===========variables for DB===================

    public static float objectXCoordinate;
    public static float objectYCoordinate;
    public static float objectZCoordinate;
    public static string objectPlacementTime;
    public static string objectGUID;
    public static int likes;
    public ObjectCreatorDB user;
    public string test;


    // Update is called once per frame
    void Update()
    {  

        //If the menu button is toggled / This is called in another script. 
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

        //When the selected button in the menu of the desired message is selected run this. 
        if (buttonToggle)
        {
        
            if (previewCube == null)
            {
                previewCube = CubePlacement(spawnPos);   
            }
            previewCube.transform.position = spawnPos;
        
            if (Cursor.visible == false){

                if (isClicked()){
                    if(Input.GetKeyDown(KeyCode.Mouse0)){
                        Destroy(previewCube);
                        //prefab.GetComponent<Renderer>().material = blueMaterial;
                        GameObject messageCube = Instantiate(placePrefab, spawnPos, Quaternion.identity);
                        //Save cube current position
                            //currentPosition = spawnPos;
                            
                            objectXCoordinate = spawnPos.x;
                            objectYCoordinate = spawnPos.y;
                            objectZCoordinate = spawnPos.z;
                            objectPlacementTime = System.DateTime.Now.ToString();
                            objectGUID = System.Guid.NewGuid().ToString();
                            likes = 0;

                            Debug.Log(objectXCoordinate);
                            Debug.Log(objectYCoordinate);
                            Debug.Log(objectZCoordinate);
                            Debug.Log(CubeMessages.messageInsideCube);
                            Debug.Log(objectPlacementTime);
                            Debug.Log(objectGUID);
                            Debug.Log(SingleMicrophoneCapture.goAudioSource);
                            Debug.Log(likes);

                        PostToDatabase();
                        //Save cube current message
                            //currentMessage = CubeMessages.messageForOutside.ToString();
                        //Save cube current like amount
                            //
                        buttonToggle = false;
                        externalButtonToggle = false;
                        //Instantiate(prefab,new Vector3(hit.point.x,hit.point.y,hit.point.z), Quaternion.identity);
                        }
                }
            }   


        } 
    }


    // Boolean toggles to make sure the mouse is used as the input device
    bool isClicked(){
        return Input.GetKeyDown(KeyCode.Mouse0);
    }

    public void buttonIsPressed(){
       buttonToggle = !buttonToggle;
    }
    
    
    //Place the cubes in space. 
    public GameObject CubePlacement(Vector3 spawnPos)
    {
        prefab.GetComponent<Renderer>().material = previewMaterial;
        GameObject previewCube = Instantiate(prefab,spawnPos, Quaternion.identity);
        return previewCube;
        
    }   

    //Upload the data to the database once the object is placed. 
    private void PostToDatabase()
    {
        ObjectCreatorDB newObject = new  ObjectCreatorDB();
        RestClient.Put(url: "https://museum-message-db.firebaseio.com/" + objectGUID + ".json", newObject);
    }



//=================OLD ATTEMPTS=========================================

    private void RetrieveFromDatabase()
    {
        RestClient.Get<ObjectCreatorDB>(url:"https://museum-message-db.firebaseio.com/.json").Then(onResolved: response =>
        {
            Debug.Log("The data was successfully retrieved from the database");
            user = response;
            GetSomethingForGoodnessSake();
        });
    }

    private void RetrieveFromDatabaseJSON()
    {
        var usersRoute = "https://museum-message-db.firebaseio.com/.json"; 
        RestClient.Get<ObjectCreatorDB>(usersRoute + "/1").Then(firstUser => {
        EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(firstUser, true), "Ok");
        });
    }

    public void GetSomethingForGoodnessSake()
    {
        test = user.message;
    }

}