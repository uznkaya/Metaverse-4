using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry;
    [SerializeField] float yBoundry;
    SoundManager soundManager;
    Delay delay;
    bool isAttacking;
    private void Start()
    {
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        delay = GameObject.Find("Level Manager").GetComponent<Delay>();
    }
    private void FixedUpdate()
    {
        EnemyAttack();  
    }
    private void Update()
    {
        EnemyDestroyer();
    }
    void EnemyDestroyer()
    {
        if((transform.position.x < xBoundry) || (transform.position.y < yBoundry))
        {
            Destroy(gameObject);
        }
    }
    void EnemyAttack()
    {
        transform.Translate(-1 * enemyAttackSpeed * Time.deltaTime, 0, 0);
        while (!isAttacking)
        {
            soundManager.AttackEnemySound();
            isAttacking = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over.");
            delay.StartDelayTime();
            soundManager.DeadByEnemySound();
            Destroy(collision.gameObject);
        }
    }
}
