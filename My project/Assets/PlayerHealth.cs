using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    UIManager uiManager;
    [SerializeField] Image[] playerHealthIcons;
    [SerializeField] int playerLifeCount = 3;
    Delay delay;

    private void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }
    public void Lives()
    {
        playerLifeCount--;
        Destroy(playerHealthIcons[playerLifeCount]);

        if (playerLifeCount < 1)
        {
            uiManager.GetComponent<Canvas>().enabled = true;
            delay.delayTime = false;
        }
    }
}
