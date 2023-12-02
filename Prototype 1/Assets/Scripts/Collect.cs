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

    private int points;
    private AudioSource soundEffect;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Respawn") // hitting collectibles
        {
            soundEffect = other.GetComponent<AudioSource>();
            soundEffect.Play();

            points = other.gameObject.GetComponent<AnimationScript>().collectible.getPointValue();
            uimanager.UpdateScore(points);

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
