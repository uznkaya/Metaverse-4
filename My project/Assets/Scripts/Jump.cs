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
    public static float gravityScale = 1f;
    public static float fallGravityScale = 15f;
    [SerializeField] float startJumpTime;
    float jumpTime;
    bool isJumping;
    bool doubleJump;
    [SerializeField] Animator anim;

    // Karakterimizin ziplamasini saglamak icin rigidBody2D, ziplama sesi cikarabilmesi icin ise SoundManager'i cekiyoruz.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        JumpAction();   
    }
    void JumpAction()
    {
        if (Movement.isDashing)
        {
            return;
        }
        //Eger Jump tusuna (space) basilir ise ve bizim karakterimiz yerde ise kodlari calistir diyoruz. 
        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelManager.canMove)
        {
            // rigidBodymize kuvvet uygulayarak ziplama saglayabiliyoruz. .AddForce(1,2)
            // 1: Karakterimize hangi yonde ne kadar ziplatmak istiyorsak onun degeri,
            // 2:Kuvvet cesidi (2 tane kuvvet cesidi var biri Impulse digeri Force) [Impulse :Tum kuvveti bir anda veriyor][Force :Yavas veriyor kuvveti roketin kalkmasi gibi dusunebiliriz]
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            doubleJump = true;
            SoundManager.instance.PlayWithIndex(9);
            jumpTime = startJumpTime;
            anim.SetBool("Jump", true);
        }
        else if(Input.GetButtonDown("Jump")&& doubleJump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            doubleJump = false;
        }
        if(Input.GetButton("Jump")&& isJumping)
        {
            if(jumpTime > 0)
            {
                rb.AddForce(Vector2.up, ForceMode2D.Force);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        if (Mathf.Approximately(rb.velocity.y, 0))
        {
            anim.SetBool("Jump", false);
        }
        Gravity();
    }
    private bool IsGrounded()
    {
        // Physics2D.OverlapCircle 2D cember icerisindeki nesneleri kontrol etmek icin kullaniliyor. Sirasiyla cemberin merkez noktasini, yaricapini ve katmanini alir.
        // Burada bizim karakterimizin havada ziplamasini engellemek icin feetPos'un etrafinda olusan cemberin icerisinde Ground var mi yok mu ona bakiyor eger var ise true alir yok ise false degerini alir.
        return Physics2D.OverlapCircle(feetPos.position,radius,layerMask);
    }

    // Biraz daha gercekcilik katmak icin burada yer cekimi adinda bir metod olusturduk. Ziplarken ve yere duserkenki yer cekmini ayarliyoruz.
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
