using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] TMP_InputField textBox;
    [SerializeField] TextMeshProUGUI infoText;

    public void Save()
    {
        PlayerPrefs.SetString("Name", textBox.text);
        infoText.text = "Your data succesfully saved";
    }
    public void Next()
    {
        SceneManager.LoadScene(1);
    }
    public void Default()
    {
        PlayerPrefs.DeleteAll();
    }
}
