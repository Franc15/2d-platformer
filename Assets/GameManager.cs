using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TMP_Text scoreText;

    public bool gameOver;

    [SerializeField]
    private Image pauseImage, gameOverImage;
    [SerializeField]
    private Button unPauseButton, mainMenuButton, pauseButton, restartButton;

    int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        gameOver = false;
        SceneManager.LoadScene("Gameplay");
    }

    public void UpdateScore()
    {
        score+=1;
        scoreText.text = "Score: " + score;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseImage.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void UnPauseGame ()
    {
        Time.timeScale = 1;
        pauseImage.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void EndGame()
    {
        gameOverImage.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        gameOver = false;
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
