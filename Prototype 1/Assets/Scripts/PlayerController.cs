using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float LANE_DISTANCE = 3.0f;
    private CharacterController controller;
    private float jumpForce = 6.0f;
    private float gravity = 12.0f;
    private float verticalVelocity;
    private float speed = 7.0f;
    private int desiredLane = 1; // 0 = Left, 1 = middle, 2 = right

    private void Start() {
        controller = GetComponent<CharacterController>();
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLane(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveLane(true);
        }


        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0) {
            targetPosition += Vector3.left * LANE_DISTANCE;
        }
        else if (desiredLane == 2) {
            targetPosition += Vector3.right * LANE_DISTANCE;
        }


        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;
        moveVector.y = -0.1f;
        moveVector.z = speed;
    }
    private void MoveLane(bool goingRight) {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2)
    }
    // private float speed = 20;
    // private float turnSpeed = 35;
    // private float horizontalInput;
    // private float forwardInput;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     forwardInput = Input.GetAxis("Vertical");

    //     // Moves the car forward based on vertical input
    //     transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);


    //     // Rotates the car based on horizontal input
    //     transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    // }
}



