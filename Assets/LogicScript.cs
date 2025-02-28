using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    public BirdScript bird;
    public AudioSource mario14;
    public GameObject gameComps;
    public bool hasGameStarted = false;
    public Text hiScore;
    public int highScore;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        if(bird.birdIsAlive){
            playerScore = playerScore +  scoreToAdd;
            scoreText.text = playerScore.ToString();
            mario14.Play();
    }}

    void Start()
{
    highScore = PlayerPrefs.GetInt("hiScore", 0);
    hiScore.text = highScore.ToString();
}

    public void checkHiScore(){
        if(playerScore > highScore){
            highScore = playerScore;
            PlayerPrefs.SetInt("hiScore",playerScore);
            hiScore.text = "High Score:" + highScore.ToString();
        }
        
    }

    public void gameStart(){
        startScreen.SetActive(false);
        gameComps.SetActive(true);
        hasGameStarted = true;
    }
    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void gameOver(){
        gameOverScreen.SetActive(true);
        checkHiScore();
    }
}
