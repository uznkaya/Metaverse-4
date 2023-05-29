using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed; // Mermi hizi degiskeni
    Rigidbody2D rb; // Mermiyi yonlendirmek ve hareketini saglamak icin alinan rigidbody2D degiskeni
    Delay delay; // Eger mermi playeri vurur ise yeniden dogmasini saglamak icin alinan delay degiskeni
    PlayerHealth playerHealth; // Yine player vurulur ise canini azaltmak icin playerHealth degiskeni
    [SerializeField] ParticleSystem groundParticle;
    [SerializeField] ParticleSystem playerDeathParticle;
    [SerializeField] ParticleSystem playerHitParticle;
    [SerializeField] ParticleSystem playerBlockParticle;
    [SerializeField] GameObject player;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Bullet'in icindeki rigidBody2D' yi cektik.
        delay = GameObject.Find("Level Manager").GetComponent<Delay>(); // Level Manager objesine giderek delay scriptini cektik. 
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>(); // Yukarida oldugu gibi Level Manager objesini ariyoruz cunku icerisindeki PlayerHealth scriptini cekelim.
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed; 
        // rb.velocity bizim merminin hareket degerini (hizini) belirtiyor. Ve biz burada transform.right metodu ile yonunu ayarliyoruz sonrasinda ise yukarida kendimizin belirledigi hiz degeri ile carpip hizini ayarliyoruz.
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject); // Eger mermi bir yere carpar ise yok et diyoruz.

        // Buradaki if blogu su ise yariyor bizim gonderdigimiz mermiler bizim player karakterimize de carpabilir. Bundan dolayi diyoruz ki eger Mermi'nin carptigi seyin Tagi "player" ise sunlari gerceklestir.
        if (collision.gameObject.CompareTag("Player")&&LevelManager.canMove && !Movement.blocking) 
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            animator.SetTrigger("Die");
            LevelManager.canMove = false;
        }else if (Movement.blocking)
        {
            Instantiate(playerBlockParticle, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(groundParticle, transform.position, Quaternion.identity);
        }
    }
}
