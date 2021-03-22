using UnityEngine;  
using UnityEngine.UI;
using System.Collections;  
using TMPro;

/*

This script manages the recording of the audio recording
Using the default audio input device selected by the computer

*/


[RequireComponent (typeof (AudioSource))]  
  
public class SingleMicrophoneCapture : MonoBehaviour   
{  
    //A boolean that flags whether there's a connected microphone  
    private bool micConnected = false;  
  
    //The maximum and minimum available recording frequencies  
    private int minFreq;  
    private int maxFreq;  
    private float timer;
    private bool IsButtonPressed= false;
    public TextMeshProUGUI timerDisplay;
    //A handle to the attached AudioSource  
    public static AudioSource goAudioSource;  

    public static bool audioWasRecorded;
  
    //Use this for initialization  
    void Start()   
    {  
        Debug.Log(goAudioSource);
        timer = 0.0f;

        //Check if there is at least one microphone connected  
        if(Microphone.devices.Length <= 0)  
        {  
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");  
        }  
        else //At least one microphone is present  
        {  
            //Set 'micConnected' to true  
            micConnected = true;  
  
            //Get the default microphone recording capabilities  
            Microphone.GetDeviceCaps(null, out minFreq, out maxFreq);  
  
            //According to the documentation, if minFreq and maxFreq are zero, the microphone supports any frequency...  
            if(minFreq == 0 && maxFreq == 0)  
            {  
                //...meaning 44100 Hz can be used as the recording sampling rate  
                maxFreq = 44100;  
            }  
  
            //Get the attached AudioSource component  
            goAudioSource = this.GetComponent<AudioSource>();  
        }  
    }  

    void Update()   
        {  
            //If there is a microphone  
            if(micConnected)  
            {  
                //If the audio from any microphone isn't being captured  
                if(!Microphone.IsRecording(null))  
                {  
                    //Case the 'Record' button gets pressed  
                    if(Input.GetKeyDown(KeyCode.R))  
                    {  
                        timerDisplay.text = "Recording Audio " + timer.ToString("0");
                        //Start recording and store the audio captured from the microphone at the AudioClip in the AudioSource  
                        goAudioSource.clip = Microphone.Start(null, true, 20, maxFreq);  
                    }  
                }
                else //Recording is in progress  
                {  
                    //Case the 'Stop and Play' button gets pressed  
                    if(Input.GetKeyUp(KeyCode.R))  
                    {  
                        timerDisplay.text = "Finished Recording";
                        Microphone.End(null); //Stop the audio recording  
                        //goAudioSource.Play(); //Playback the recorded audio  
                        timerDisplay.gameObject.SetActive(false);
                        
                        Placing_Object.externalButtonToggle = true;
                        audioWasRecorded = true;
                    }  
                    //GUI.Label(new Rect(Screen.width/2-100, Screen.height/2+25, 200, 50), "Recording in progress...");  
                }  
            }  
            else // No microphone  
            {  
                //Print a red "Microphone not connected!" message at the center of the screen  
                GUI.contentColor = Color.red;  
                GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-25, 200, 50), "Microphone not connected!");  
            }  
    
        }  
    public void ButtonIsPressed()
    {
        IsButtonPressed = true;
        timerDisplay.gameObject.SetActive(true);
        timerDisplay.text = "Press key to begin recording";

    }
}  