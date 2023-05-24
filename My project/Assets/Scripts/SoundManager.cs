using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    public AudioClip[] sounds;

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
        }
    }
    #endregion

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWithIndex(int index)
    {
        audioSource.PlayOneShot(sounds[index]);
    }

}
