using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEditor;
using TMPro;

/*

This script manages the Database creating the object for it to upload
the information to Firebase. 

*/



public class DatabaseManager : MonoBehaviour
{

    //Variables and list used in the script
    List<string> primaryKeys = new List<string>();
    public GameObject placePrefab;
    public static string getthisOut;

    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(GetDataFromDatabase());
    }

    // Update is called once per frame


    //Routine to get, and retrieve information from the database and populate the spatial objects
    IEnumerator GetDataFromDatabase()
    {

        string URL = "https://museum-message-db.firebaseio.com/.json";

        UnityWebRequest cubeInfoRequest = UnityWebRequest.Get(URL);

        yield return cubeInfoRequest.SendWebRequest();

        if(cubeInfoRequest.isNetworkError || cubeInfoRequest.isHttpError)
        {
            Debug.Log(cubeInfoRequest.error);
            yield break;
        }   

        JSONNode cubeInformation = JSON.Parse(cubeInfoRequest.downloadHandler.text);
        
        // Test to see dtaa being gathered correctly
        //string xCoordinate = cubeInformation["9446f0fd-0537-4bc8-b1a8-6860b8b8bebf"]["xCoordinate"];
        //tring xCoordinate = cubeInformation[1]["xCoordinate"];
        //Debug.Log(xCoordinate);
        //TextMeshProUGUI anotherMessage = placePrefab;    

        int counter = 0;


        // Go through the list of the differnet information on the JSON file.
        if (cubeInformation != null)
        {
            foreach(var cubeObjects in cubeInformation)
            {            
                float xCoordinate = cubeInformation[counter]["xCoordinate"];
                float yCoordinate = cubeInformation[counter]["yCoordinate"];
                float zCoordinate = cubeInformation[counter]["zCoordinate"];
                string message = cubeInformation[counter]["message"];
                string GUID = cubeInformation[counter]["GUID"];
                int likes = cubeInformation[counter]["likeAmount"];

                LikeCounter.externalLikeCounter = likes;
                Vector3 spawnPos = new Vector3(xCoordinate, yCoordinate, zCoordinate);
                GameObject messageCube = Instantiate(placePrefab, spawnPos, Quaternion.identity);
                CubeMessages.messageInsideCube = message;
                message = getthisOut;
                //Debug.Log(cubeInformation[counter]["GUID"]);
                counter++;
            }
        }
        
        //If there are no messages on the database this will display on the console. 
        else 
        {
            Debug.Log("No messages found in database");
        }

    }

}


