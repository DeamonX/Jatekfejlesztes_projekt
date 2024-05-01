using TMPro;
using UnityEngine;
using UnityEngine.UI;


/* A játékot körül ölelő programrész, itt található minden olyan funkció,
 amit a játék során felhasználunk és nem objektum specifikus */
public class GameManager : MonoBehaviour
{
    // Főhősünk, galamb.
    public Galamb player;
    // Jelenleg elért pontokat megjelenítő szöveg elem.
    public TextMeshProUGUI  scoreText;
    // Játék kezdete gomb
    public GameObject playButton;
    // Játék vége gomb.
    public GameObject gameOver;

    // Elért pontok, privát érték más objektum nem fér hozzá.
    private int score;

    // Indítás során először végrehajtódó függvény, "ébredő" 
    private void Awake(){
        // 60 FPS
        Application.targetFrameRate = 60;

        // Alapértelmezetten felhasználói interakció kell az indításhoz, szóval Pause a kezdő állapot.
        Pause();
    }

    // Játék indító függvény
    public void Play(){
        // pontok nullázása
        score = 0;

        // Pontot kiíró szöveg elem frissítése a nullázott ponttal.
        scoreText.text = score.ToString();


        // eltűntetjük a játék kezdés és vége elemeket.
        playButton.SetActive(false);
        gameOver.SetActive(false);


        // Beállítunk egy alapértelmezett idő gyorsaságot
        Time.timeScale = 1f;

        // Elindítjuk a Galamb onEnabled függvényét.
        player.enabled = true;


        // Megkeressük a pályán lévő összes Cso elemet és eltároljuk a csovek tombbe.
        Csovek[] csovek = FindObjectsOfType<Csovek>();

        // Át iterálunk a tömbbön foreach segítségével és egyesével töröljük az elemet.
        foreach(Csovek cso in csovek){
            Destroy(cso.gameObject);
        }
    }
    // Szünet állapot, megáll az idő múlása és kikapcsoljuk a galambot.
    public void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;
    }
    // Megjelenítjük a játék vége és a játék kezdete gombot, szünet állapot.
    public void GameOver(){
        gameOver.SetActive(true);
        playButton.SetActive(true);
        
        Pause();
    }

    // Amint sikeresen túlélte az adott akadályt megnöveljük a pontot és frissítjük a felületen a kiírást.
    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }
}
