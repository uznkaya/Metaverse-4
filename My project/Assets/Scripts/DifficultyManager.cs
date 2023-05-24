using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    [HideInInspector]
    public bool easyMode, normalMode, hardMode;
    private void Start()
    {
        PlayerPrefs.DeleteKey("Easy Mode");
        PlayerPrefs.DeleteKey("Normal Mode");
        PlayerPrefs.DeleteKey("Hard Mode");

        easyMode = false;
        normalMode = false;
        hardMode = false;
    }
    public void EasyMode()
    {
        easyMode = true;
        PlayerPrefs.SetInt("Easy Mode", easyMode ? 1 : 0);
        SceneManager.LoadScene(1);
        LevelManager.countForWin = 1;
    }
    public void NormalMode()
    {
        normalMode = true;
        PlayerPrefs.SetInt("Normal Mode", normalMode ? 1 : 0);
        SceneManager.LoadScene(1);
        LevelManager.countForWin = 3;
    }
    public void HardMode()
    {
        hardMode = true;
        PlayerPrefs.SetInt("Hard Mode", hardMode ? 1 : 0);
        SceneManager.LoadScene(1);
        LevelManager.countForWin = 5;
    }
}
