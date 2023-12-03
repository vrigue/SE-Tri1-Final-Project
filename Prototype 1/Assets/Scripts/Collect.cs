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
            other.gameObject.transform.position -= new Vector3(0, 10, 0);

            points = other.gameObject.GetComponent<AnimationScript>().collectible.getPointValue();
            uimanager.UpdateScore(points);

            soundEffect = other.gameObject.GetComponent<AudioSource>();
            soundEffect.Play();

            StartCoroutine(destroyCollectible(other.gameObject));  
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

    public IEnumerator destroyCollectible(GameObject collectible)
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(collectible); 
    }
}
