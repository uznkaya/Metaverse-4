using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Canvas canvas;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    private void Update()
    {
        scoreText.text = "Your Score : " + ScoreManager.score.ToString();
        ScoreManager.highScore = PlayerPrefs.GetInt("High Score");
        highScoreText.text = "High Score : " + ScoreManager.highScore.ToString();
    }

    public void RestartButton() // Oyunumuzu yeniden baslatmasini saglayan metod.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // .LoadScene() : parantez icerisinde yazili olan index degerine sahip sahneyi yukler.
        canvas.enabled = false; // Oyun bittigi zaman bizim canvasimiz etkin oluyordu. Bunu devre disi birakiyoruz
        LevelManager.knifeStop = false;
        ScoreManager.score = 0;

        if (PlayerPrefs.HasKey("Easy Mode"))
        {
            LevelManager.countForWin = 1;
        }
        else if (PlayerPrefs.HasKey("Normal Mode"))
        {
            LevelManager.countForWin = 3;
        }
        else if (PlayerPrefs.HasKey("Hard Mode"))
        {
            LevelManager.countForWin = 5;
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
        LevelManager.knifeStop = false;
    }
}
