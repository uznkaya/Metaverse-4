using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpPower;
    [SerializeField] private float radius;
    [SerializeField] private Transform feetPos;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float gravityScale;
    [SerializeField] private float fallGravityScale;
    private SoundManager soundManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            soundManager.JumpSound();
        }
        Gravity();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position,radius,layerMask);
    }
    void Gravity()
    {
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if(rb.velocity.y < 0){
            rb.gravityScale = fallGravityScale;
        }
    }
}
