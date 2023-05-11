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
        ScoreManager.score = 0;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene(0);
        ScoreManager.score = 0;
    }
}
