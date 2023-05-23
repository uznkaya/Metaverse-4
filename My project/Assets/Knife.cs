using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] ParticleSystem particle;
    [SerializeField] float destroyLimit;

    [Header("Mode Speed")]
    [SerializeField] float easySpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float hardSpeed;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (transform.position.x < destroyLimit)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }
    private void HardenedLevel()
    {
        if(PlayerPrefs.HasKey("Easy Mode"))
        {
            moveSpeed -= easySpeed;
        }
        else if(PlayerPrefs.HasKey("Normal Mode"))
        {
            moveSpeed = normalSpeed;
        }
        else if(PlayerPrefs.HasKey("Hard Mode"))
        {
            moveSpeed += hardSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.KnifeSound();
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            PlayerHealth.instance.Lives();
            Movement.Cancel();
            Delay.instance.StartDelayTime();
            Destroy(gameObject);
        }
    }
}