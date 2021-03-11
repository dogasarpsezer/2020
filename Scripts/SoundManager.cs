using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager playerSoundManager;
    [SerializeField]
    private AudioSource mySource;
    private void Awake()
    {
        mySource = transform.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerSoundManager.getBool())
        {
            mySource.PlayOneShot(playerSoundManager.getAudioClip());
        }
    }

}
