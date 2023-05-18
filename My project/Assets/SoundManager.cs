using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Indekleme olayi ile toparla burayi
    // Ses Kaynaklarini atamak icin gerekli degiskenleri olusturduk.
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
    [SerializeField] AudioClip deadByEnemySound;
    [SerializeField] AudioClip deadByFallSound;
    [SerializeField] AudioClip attackEnemySound;
    [SerializeField] AudioClip runDoorSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip knifeSound;

    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Sahnede fazladan sound manager olamaz");
        }
    }
    #endregion

    // Sesleri calistabilmek icin bir ses kaynagi lazim bundan dolayi Start metodu icerisinde gerekli olan audioSource'u cektik.
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // audioSource.PlayOneShot metodu(parametre); PlayOneShot metodu parametre olarak verilen sesi bir kez calmasini saglar. 

    // Ziplama Sesi
    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        Debug.Log("Jumped");
    }

    // Zemin Sesi
    public void LandSoundSound()
    {
        audioSource.PlayOneShot(landSound);
        Debug.Log("Land");
    }

    // Dusman tarafindan olme sesi
    public void DeadByEnemySound()
    {
        audioSource.PlayOneShot(deadByEnemySound);
        Debug.Log("Dead by Enemy");
    }

    // Asagiya duserek olme sesi
    public void DeadByFallSound()
    {
        audioSource.PlayOneShot(deadByFallSound);
        Debug.Log("Dead by Fall");
    }

    // Enemylerin saldiri sesi
    public void AttackEnemySound()
    {
        audioSource.PlayOneShot(attackEnemySound);
        Debug.Log("Enemy Attacked");
    }

    public void RunDoorSound()
    {
        audioSource.PlayOneShot(runDoorSound);
        Debug.Log("Run door");
    }
    public void WinSound()
    {
        audioSource.PlayOneShot(winSound);
        Debug.Log("Win");
    }
    public void KnifeSound()
    {
        audioSource.PlayOneShot(knifeSound);
        Debug.Log("Knife");
    }

}
