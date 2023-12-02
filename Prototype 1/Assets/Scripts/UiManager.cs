using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text restartText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject startPanel;
    public bool isGameOver = false;
    public bool isGameOverWin = false;
    private AudioSource carCrash;


    // Start is called before the first frame update
    void Start()
    {
        //Disables panel if active
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        restartText.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // trigger game over manually and check with bool so it isn't called multiple times
        if (Input.GetKeyDown(KeyCode.G) && !isGameOver)
        {
            isGameOver = true;

            StartCoroutine(GameOverSequence());
        }

        

        //If game is over
        if (isGameOver || isGameOverWin)
        {

            // if r is hit restart current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            // if q is hit quit game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    // controls game over canvas so there's dely between u lost lol and the restart/quit
    public IEnumerator GameOverSequence()
    {
        carCrash = GetComponent<AudioSource>();
        carCrash.Play();
        
        gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);
    }

    public IEnumerator GameOverSequenceWin()
    {
        winPanel.SetActive(true);

        yield return new WaitForSeconds(5.0f);

        restartText.gameObject.SetActive(true);
    }
}
