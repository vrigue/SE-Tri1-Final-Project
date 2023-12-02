using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Collect : MonoBehaviour
{
    public UiManager uimanager;
    public PlayerController playerController; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Respawn") // hitting collectibles
        {
         Destroy(other.gameObject);   
        }
        else if(other.gameObject.tag == "Finish") // hitting wall at end
        {
            Debug.Log("win");
            uimanager.isGameOver = true;
            playerController.speed = 0;
            playerController.leftRightSpeed = 0;
            playerController.moveSpeed = 0;

            StartCoroutine(uimanager.GameOverSequenceWin());
        }
        else if(other.gameObject.tag == "EditorOnly") // hitting obstacle
        {
            Debug.Log("lose");
            uimanager.isGameOver = true;

            StartCoroutine(uimanager.GameOverSequence());
            playerController.speed = 0;
            playerController.leftRightSpeed = 0;
            playerController.moveSpeed = 0;
        }

    }
}
