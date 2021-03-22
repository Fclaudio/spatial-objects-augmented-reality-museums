using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*

This is the main script working with the spatial menu in this case it is called
Pause Menu. This just turn the menu on and off based on a key toggle. 

*/

public class PauseMenu : MonoBehaviour
{

    // Variables used in script.
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public bool cursorIsVisible = true;
    public bool cursorIsNotVisible = false;



    void Start()
    {
        turnButtonsOff();
    }

    // Update is called once per frame
    void Update()
    {
        //The use of this key stroke is and old referene used to pause and resume the game
        //Although it is still implemented it is not currently supposed to be used.
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    void Resume(){
        pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = cursorIsNotVisible;
        turnButtonsOff();
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        //Time.timeScale = 1f;
        gameIsPaused = true;
        Cursor.visible = cursorIsVisible;
        turnButtonsOff();      
    }

    public void PressButtonAtMainMenu(){
        if (button1.activeSelf == false){
            turnButtonsOn();
        }
        else{
            turnButtonsOff();
        	}
        }

    void turnButtonsOff()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
    }

    void turnButtonsOn()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        button5.SetActive(true);
    }

}

