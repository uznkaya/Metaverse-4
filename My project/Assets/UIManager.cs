using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Canvas canvas;
    private void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    public void RestartButton() // Oyunumuzu yeniden baslatmasini saglayan metod.
    {
        SceneManager.LoadScene(0); // .LoadScene() : parantez icerisinde yazili olan index degerine sahip sahneyi yukler.
        canvas.enabled = false; // Oyun bittigi zaman bizim canvasimiz etkin oluyordu. Bunu devre disi birakiyoruz
    }
}
