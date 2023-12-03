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
    public TextMeshProUGUI scoreText;

    public bool isGameOver = false;
    public bool isGameOverWin = false;

    private AudioSource carCrash;
    private int score;

    delegate void SoundDelegate();
    SoundDelegate soundDelegate;

    // Start is called before the first frame update
    void Start()
    {
        // Disables panel if active
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        restartText.gameObject.SetActive(false);

        score = 0;
        UpdateScore(0);
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

        
        // if game is over
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

    void playCarCrashSound() 
    {
        carCrash = GetComponent<AudioSource>();
        carCrash.Play();
    }

    public void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // controls game over canvas so there's a delay between "u lost lol" and the restart/quit
    public IEnumerator GameOverSequence()
    {
        soundDelegate = playCarCrashSound;
        soundDelegate();
        
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