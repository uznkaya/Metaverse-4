using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawnPos;
    [SerializeField] GameObject friesPrefab;
    [SerializeField] public int count;
    [SerializeField] GameObject door;
    public bool canWin;
    public static bool canMove = true;

    // Awake : Starttan once calisir. Genelde sahne baslatma ve referans alma islemleri icin kullanilir. 
    private void Awake()
    {
        PlayerSpawner(); // Playerimizi olusturduk.
    }
    private void Start()
    {
        StartDelayFries();
    }

    // Instantiate : GameObject olusturmamizi saglar. Bizden 3 adet parametre ister. Bunlar sirasiyla olusturmak istedigimiz nesne, nesnenin olusturacagi pozisyon ve rotasyonu (yonu)
    // Quaternion.identity : Rotation degerlerini otomatik 0 ayarlayan kod.

    void PlayerSpawner() // Playeri spawnlayan metod.
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity); 
    }
    public void RespawnPlayer() // Playeri yeniden spawnlayan metod.
    {
        Instantiate(playerPrefab, playerSpawnPos.position, Quaternion.identity);
    }
    public void FriesSpawner() // Frieslari spawnlayan metod.
    {
        // Frieslarimizi oyun icerisinde rastgele yerlerde spawnlamak icin Rastgele x ve y degeri olusturan bir Vector3 olusturuyoruz.
        Vector3 spawnPos = new Vector3(Random.Range(-8.4f,8.4f),Random.Range(-4,0),0); 
        Instantiate(friesPrefab, spawnPos, Quaternion.identity);
    }

    public void StartDelayFries()
    {
        StartCoroutine(DelayFries());
    }

    public IEnumerator DelayFries()
    {
        if(count == 5)
        {
            canWin = true;
            door.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        if(count < 5)
        {
            FriesSpawner();
        }
    }
}
