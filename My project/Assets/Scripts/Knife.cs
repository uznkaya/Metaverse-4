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
    [SerializeField] GameObject player;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = HardenedScript.instance.HardenedLevel(moveSpeed, easySpeed, normalSpeed, hardSpeed);
    }
    private void Update()
    {
        if (transform.position.x < destroyLimit)
        {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(-transform.right * turnSpeed);
        rb.velocity = Vector2.left * moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlayWithIndex(10);
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);      
            PlayerHealth.instance.Lives();
            Movement.Cancel();
            if (Delay.instance.delayTime)
            {
                Delay.instance.StartDelayTime();
            }
            Destroy(gameObject);

        }
    }
}
