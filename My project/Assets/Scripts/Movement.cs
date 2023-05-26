using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    static private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed;
    [SerializeField] float playerYBoundry;
    Delay delay;
    PlayerHealth playerHealth;
    TrailRenderer tr;
    Jump jump;
    private float horizontalMove;

    public static bool dashed;
    public static bool canDash = true;
    public static bool isDashing = false;
    public static bool blocking = false;
    [SerializeField] float dashAmount;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashTime;
    [SerializeField] Animator anim;

    void Start()
    {
        Cancel();
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
        playerHealth = GameObject.Find("Level Manager").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        jump = GetComponent<Jump>();
    }

    // Surekli olarak karakterimiz hareket edecegi icin veya ne zaman asagiya duserek olecegini bilemedigimiz icin bu iki metodu Update icerisinde calistiriyoruz.
    void Update()
    {
        MovementAction();
        PlayerDestroyer();
        StartDash();
        Block();
    }

    // Karakterimizin hareket etmesini saglayan metod. Once saga veya sola gitme duruma bagli olarak horizontalMove degiskenine -1 veya +1 atiyoruz. Bunu kontrol etmek icin ise Input.GetAxis("Horizontal") ile sagliyoruz. Horizontal yazmamizin sebebi su Unity bizim icin kolaylik saglamis. A veya sol ok basma durumunda -1, D veya sag ok basma durumunda +1 degeri donduruyor. Bizde bu duruma gore rigidBody2D ye velecotiy hiz vererek hareket etmesini sagliyoruz. Daha sonrasinda ise karakterimiz hangi yone bakmasi gerekiyor ise o yone dogru Flipleme (dondurme) islemini gerceklestiriyoruz.
    void MovementAction()
    {
        if (isDashing)
        {
            return;
        }

        if (LevelManager.canMove)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
            SpriteFlip(horizontalMove);
            anim.SetFloat("Move", Mathf.Abs(horizontalMove));
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    // Karakterimizin sahip oldugu spriteRenderer icerisinde karakterimizi otomatik dondurmemizi saglayan .flipX metodu bulunuyor. Karakterimizin sola dogru gidiyorsa .flipX cevirerek karakterin donmesini sagliyoruz. Eger saga gidiyorsa donmesini iptal ediyoruz. SpriteFlip metodu karakterin hareket ettigi yone dogru bakmasini saglayan metod.
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

    // Karakterimiz asagiya duserek olebilir. PlayerDestroyer metodunda bu olayi gerceklestiriyoruz.
    void PlayerDestroyer()
    {
        if (transform.position.y < playerYBoundry)
        {
            SoundManager.instance.PlayWithIndex(4);
            Destroy(gameObject);
            Movement.Cancel();
            playerHealth.Lives();
            if (delay.delayTime == true)
            {
                delay.StartDelayTime();
            }
        }
    }

    void StartDash()
    {
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove != 0)
        {
            StartCoroutine(Dash());
            SoundManager.instance.PlayWithIndex(2);
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        Jump.fallGravityScale = 0f;
        tr.emitting = true;
        rb.velocity = new Vector2(dashAmount * horizontalMove,0f);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = 1f;
        Jump.fallGravityScale = 15f;
        tr.emitting = false;
        isDashing = false;
        dashed = true;
        yield return new WaitForSeconds(dashCooldown);
        dashed = false;
        canDash = true;
    }

    public static void Cancel()
    {
        canDash = true;
        isDashing = false;
        dashed = false;
        Jump.fallGravityScale = 15f;
        LevelManager.canMove = true;
    }

    public void Die()
    {
        Destroy(gameObject);
        PlayerHealth.instance.Lives();
        Cancel();
        if (Delay.instance.delayTime)
        {
            Delay.instance.StartDelayTime();
        }
    }
    public void Block()
    {
        if (Input.GetMouseButton(0)&& jump.IsGrounded())
        {
            anim.SetBool("Shield", true);
            blocking = true;
            rb.velocity = Vector2.zero;
            LevelManager.canMove = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Shield", false);
            blocking = false;
            LevelManager.canMove = true;
        }
    }
}
