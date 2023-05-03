using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip landSound;
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
}
