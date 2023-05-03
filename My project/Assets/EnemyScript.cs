using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float xBoundry;
    [SerializeField] float yBoundry;

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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over.");
            Destroy(collision.gameObject);
        }
    }
}
