using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deadByEnemySound;
    [SerializeField] AudioClip deadByFallSound;
    [SerializeField] AudioClip attackEnemySound;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("Jumped");
    }
    public void LandSoundSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("Land");
    }

    public void DeadByEnemySound()
    {
        audioSource.PlayOneShot(deadByEnemySound);
        Debug.Log("Dead by Enemy");
    }
    public void DeadByFallSound()
    {
        audioSource.PlayOneShot(deadByFallSound);
        Debug.Log("Dead by Fall");
    }
    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("Enemy Attacked");
    }

}
