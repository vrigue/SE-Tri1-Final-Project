using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // enum Postion
    // {
    //     Left,
    //     Middle,
    //     Right
    // }
    // public void Update()
    // {
    //     Position pos = Position.Middle;
    //     switch(pos)
    //     {
    //         case Input.GetKeyDown(KeyCode.LeftArrow):
    //             pos = Position.Left;
    //             break;
    //     }
    // }


    public float speed = 20;
    // //private float turnSpeed = 35;
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed = 3.0f;
    public float leftRightSpeed = 4.0f;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        //      transform.position = new Vector3(-5,0,6);
        // }
        // if (Input.GetKeyDown(KeyCode.RightArrow)) {
        //     transform.position = new Vector3(5,0,6);
        // }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * 1.0f);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1.0f);
            }
        }

    }
}



