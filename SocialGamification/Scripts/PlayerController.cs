using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script manages the movement of the player. 

public class PlayerController : MonoBehaviour
{
    //Variables used in script
    public float speed;
    public float jumpForce;
    private Rigidbody rb;
    public float jumpRaycastDistance;

    // Start is called before the first fram e update
    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        
        if (Cursor.visible == false){
            Jump();
            Move();
        }

    //=============================FUNCTION AFTER HERE ==========================

    //Make the player jump
    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space)){
            if (IsGrounded()){
                rb.AddForce(0,jumpForce, 0, ForceMode.Impulse);
            }
            
        }
    }
    //Return true if the object is grounded
    bool IsGrounded(){
        return (Physics.Raycast(transform.position, Vector3.down,jumpRaycastDistance));
    }

    void Move(){
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalAxis, 0, verticalAxis) * speed * Time.deltaTime;
        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);
    }


    }


}

