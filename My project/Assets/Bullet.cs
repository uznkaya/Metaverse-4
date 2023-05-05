using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    Rigidbody2D rb;
    Delay delay;
    PlayerHealth playerHealth;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
    }
    private void FixedUpdate()
    {
        rb.velocity = -transform.right * bulletSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerHealth.Lives();
            if (delay.delayTime)
            {
                delay.StartDelayTime();
            }
        }
    }
}
