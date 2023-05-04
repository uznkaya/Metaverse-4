using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed;
    [SerializeField] float playerYBoundry;
    LevelManager levelManager;
    SoundManager soundManager;
    Delay delay;
    Canvas canvas;
    PlayerHealth playerHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        canvas = GameObject.Find("UI Manager").GetComponent<Canvas>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();    
    }
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
    }

    void MovementAction()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
        SpriteFlip(horizontalMove);
    }
    void SpriteFlip(float horizontalMove)
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    void PlayerDestroyer()
    {
        if(transform.position.y < playerYBoundry)
        {
            soundManager.DeadByFallSound();
            Destroy(gameObject);
            playerHealth.Lives();
            if (delay.delayTime == true)
            {
                delay.StartDelayTime();
            }   
            
            
        }
    }
   
}
