using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI loadText;

    private void Update()
    {
        if (PlayerPrefs.HasKey("Name"))
        {
            loadText.text = "Your name is " + PlayerPrefs.GetString("Name");
        }
        else
        {
            loadText.text = "There is no registered player";
        }
    }
}
