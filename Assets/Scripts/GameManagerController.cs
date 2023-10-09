using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour
{
    public static GameManagerController instance;
    public GameObject gameOverPanel;
    public Text ScoreUI;
    public Text HighScoreUI;
    public Text EndScoreUI;
    private int score = 0;
    private AudioSource audioSource;
    public AudioClip gameOverSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ScoreUI.text = "Peang Point : " + score.ToString();
        HighScoreUI.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        EndScoreUI.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
        SpawnPointController.instance.StopSpawn();
        StopScroll();
        gameOverPanel.SetActive(true);
    }

    private void StopScroll()
    {
        TextureScroll[] textureScrolls = FindObjectsOfType<TextureScroll>();
        GroundScroll[] groundScrolls = FindObjectsOfType<GroundScroll>();
        ObstacleController[] obstacleControllers = FindObjectsOfType<ObstacleController>();
        foreach (TextureScroll textureScroll in textureScrolls)
        {
            textureScroll.StopScroll();
        }
        foreach (GroundScroll groundScroll in groundScrolls)
        {
            groundScroll.StopScroll();
        }
    }

    public void IncreaseScore()
    {
        score++;
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            HighScoreUI.text = "High Score : " + score.ToString();
            EndScoreUI.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        ScoreUI.text = "Peang Point : " + score.ToString();
    }
}
