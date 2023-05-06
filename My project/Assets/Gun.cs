using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Vector2 direction; // Silahin bakicagi yon icin olusturdugumuz degisken
    Vector2 target; // Hedefin yon degerlerini almak icin olusturdugumuz degisken
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawnPos;

    // Karakterimiz surekli hareket edecegi icin silahimizinda surekli olarak takip etmesi gerekiyor. Bundan dolayi GunDirection metodu Update icerisinde yazili.
    void Update()
    {
        GunDirection(); 

        // Buradaki if blogu gecici olarak mermimiz dogru yonde gidiyor mu gitmiyor mu buna bakmak icin yaptik. Yinede buradaki if blogu mouse sol tusuna basar isek BulletSpawn ile mermi olusturmamizi sagliyor.
        if (Input.GetMouseButton(0)) 
        {
            BulletSpawn();
        }
    }

    // Silahin playeri hedeflemesi icin olusturdugumuz metod.
    void GunDirection()
    {
        // Once oyunda Player tagine sahip bir GameObjesi var mi yok mu onu kontrol ediyoruz ve var ise player degiskenine atiyoruz.
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 

        if(player != null) // Eger player var ise bizim bu kodlarimiz calisacak.
        {
            target = player.transform.position; // Once playerin pozisyonunu aliyoruz cunku silahin hedefi o olacak. 
            direction = target - (Vector2)transform.position; // Daha sonra burada hedef ile silahimizin arasindaki farki alarak bir nevi merminin gidecegi yon vektorunu aliyoruz.
            transform.right = -direction; // Nesnenin yonunu ayarladik. Silahin ters tarafindan cikmamasi icin ise - olarak aliyoruz.
        }
    }

    void BulletSpawn()
    {
        Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
    }
}