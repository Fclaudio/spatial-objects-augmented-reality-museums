using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*

This script created the object that will hold all the data
that will be uploaded into the database on Firebase
*/


[Serializable]
public class ObjectCreatorDB
{
public string GUID;
public string message;
public string objectTimePlacement;
public float xCoordinate;
public float yCoordinate;
public float zCoordinate;

public int likeAmount;
public AudioSource audioMessage;
public ObjectCreatorDB()
{
    message = CubeMessages.messageInsideCube;
    xCoordinate = Placing_Object.objectXCoordinate;
    yCoordinate = Placing_Object.objectYCoordinate;
    zCoordinate = Placing_Object.objectZCoordinate;
    objectTimePlacement = Placing_Object.objectPlacementTime;
    GUID = Placing_Object.objectGUID;
    audioMessage = SingleMicrophoneCapture.goAudioSource;
    likeAmount = Placing_Object.likes;
}

}

