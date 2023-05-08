using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    LevelManager levelManager;
    private void Awake()
    {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Fries'in triggerina carpan(giren) seyin tagi "player" ise once fries'i yok et daha sonrasinda ise LevelManager scripti icerisindeki .FriesSpawner metodu ile yeni bir Fries spawnla(olustur) 
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            levelManager.count++;
            levelManager.StartDelayFries();    
        }
    }
}
