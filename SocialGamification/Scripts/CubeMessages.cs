using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*

This script works with the messages inside the objects.

Managin their orientation and the different message types that
can be stored within the object. 

*/

public class CubeMessages : MonoBehaviour
{
    // Variables used in the script.
   private GameObject player;
   public GameObject messageObject;
   public GameObject canvas;
   public GameObject thumbsUpCanvas;
   public Camera playerCamera;
   public Material blueMaterial;
   public Material previewMaterial;
   public TextMeshProUGUI insideMessage;
   //Set visibility distance
   const float visibilityDistance = 4.0f;
   private AudioSource cubeAudioSource = null;  

    //===========Variables for DB===================
    public static string messageInsideCube;
    public static string anotherOne; 
    public static string cubeGUID;

   // Start is called before the first frame update
    void Start()
    {
        //Look for the game objects
        player = GameObject.Find("Player");
        
        //Get the attached AudioSource component  
        cubeAudioSource = this.GetComponent<AudioSource>();

        Debug.Log(DatabaseManager.getthisOut);
    }

    // Update is called once per frame
    void Update()
    {

        //Calculae distance between cube and player
        float distance = Vector3.Distance(player.transform.position, messageObject.transform.position);
        //Debug.Log(distance);

        //Make text face the user
        canvas.transform.LookAt(2 * canvas.transform.position - player.transform.position);
        thumbsUpCanvas.transform.LookAt(2 * canvas.transform.position - player.transform.position);

        //Attach the audio to the object if it was recorded
        if(SingleMicrophoneCapture.audioWasRecorded)
        {
            cubeAudioSource = SingleMicrophoneCapture.goAudioSource;
            SingleMicrophoneCapture.audioWasRecorded = false;
        }
        
        //{lay audio message if it has one
        if(distance < 4 && cubeAudioSource != null)
        {
            cubeAudioSource.Play();
        }
    
    }

    //==============CUBE MESSAGES======================


    //These functions will the triggered from the menu script. 
    public void ChangeText_HappyFace(){
        insideMessage.text = "<sprite=3>";
        messageInsideCube = insideMessage.text.ToString();
    }
    public void ChangeText_SadFace(){
        insideMessage.text = "<sprite=2>";
        messageInsideCube = insideMessage.text.ToString();
    }
    public void ChangeText_NeutralFace(){
        insideMessage.text = "<sprite=6>";
        messageInsideCube = insideMessage.text.ToString();
    }
    public void ChangeText_AmazedFace(){
        insideMessage.text = "<sprite=1>";
        messageInsideCube = insideMessage.text.ToString();
    }
    public void ChangeText_FunnyFace(){
        insideMessage.text = "<sprite=5>";
        messageInsideCube = insideMessage.text.ToString();
    }
    public void ChangeText_BoredFace(){
        insideMessage.text = "<sprite=4>";
        messageInsideCube = insideMessage.text.ToString();
    }

    //==============AUDIO ICON======================

    public void ChangeText_SoundIcon(){
        insideMessage.text = "<sprite=17>";
        messageInsideCube = insideMessage.text.ToString();
    }
    
}