using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] float delayTimer;
    private void Start()
    {
        levelManager = GetComponent<LevelManager>();
    }

    public void StartDelayTime()
    {
        StartCoroutine(DelayNewTime());
    }

    IEnumerator DelayNewTime()
    {
        yield return new WaitForSeconds(delayTimer);
        levelManager.RespawnPlayer();
    }
}
