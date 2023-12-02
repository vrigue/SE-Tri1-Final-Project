using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    private float horizontalInput;
    private float forwardInput;
    public float moveSpeed = 3.0f;
    public float leftRightSpeed = 4.0f;

    public enum Movement {
        None,
        Left,
        Right
    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        Movement move = Movement.None;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move = Movement.Left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            move = Movement.Right;
        }

        switch (move)
        {
  
            case Movement.Left:
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * 1.0f);
                }
                break;

            case Movement.Right:
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1.0f);
                }
                break;
        }


        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
        //         transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * 1.0f);
        //     }
        // }
        // if (Input.GetKey(KeyCode.RightArrow)) {
        //     if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
        //         transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1.0f);
        //     }
        // }

    }

}