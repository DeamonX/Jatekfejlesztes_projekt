using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Galamb player;
    public TextMeshProUGUI  scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    private void Awake(){
        Application.targetFrameRate = 60;

        Pause();
    }

public void Play(){
    score = 0;



    scoreText.text = score.ToString();

    playButton.SetActive(false);
    gameOver.SetActive(false);
    
    Time.timeScale = 1f;
    player.enabled = true;

    Csovek[] csovek = FindObjectsOfType<Csovek>();

    foreach(Csovek cso in csovek){
        Destroy(cso.gameObject);
    }
}
public void Pause(){
    Time.timeScale = 0f;
    player.enabled = false;
}
    public void GameOver(){
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }

}
