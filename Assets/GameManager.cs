using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.Scripting.LifecycleManagement;

public class GameManager : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;   
    public GameObject heart3;
    public GameObject gameOverUI;
    public GameObject pressToRestartUI;
    public TMP_Text pressKeytoStartText;
    public TMP_Text presstoContinueText;
    private CoinSpawner coinSpawner;
    private bool waitingToStart = true;
    private BallMovement ball;
    public int life = 3;
    public bool gameOver = false;
    public TMP_Text scoreText;
    private int score = 0;
    void Start()
    {
        ball = FindAnyObjectByType<BallMovement>();
        coinSpawner = FindAnyObjectByType<CoinSpawner>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameOver == true)
            {
                RestartGame();
            } 
        }

        if (waitingToStart && Input.anyKeyDown)
        {
            waitingToStart = false;
            ball.SetRandomVelocity();
            pressKeytoStartText.gameObject.SetActive(false);
            presstoContinueText.gameObject.SetActive(false);
            coinSpawner.StartSpawning();
        }
    }

    public void LoseLife()
    {
        waitingToStart = true;
        coinSpawner.StopSpawning();
        coinSpawner.DestroyAllCoins();
        life--;
        Debug.Log("Life: " + life);
        UpdateHeartsUI();
        if (life <= 0)
        {
            GameOver();
        }
        else
        {
            presstoContinueText.gameObject.SetActive(true);
            ball.RestartBall();            
        }
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        pressToRestartUI.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHeartsUI()
    {
        heart1.SetActive(life >=1);
        heart2.SetActive(life >=2);
        heart3.SetActive(life >=3);
    }

    public void AddCoinScore()
    {
        score += 5;
        scoreText.text = "Score: " + score.ToString();
    }
}
