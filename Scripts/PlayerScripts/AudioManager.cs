using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource soundSource;
    private AudioClip clipToPlay;
    private bool newSound = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sound"))
        {
            clipToPlay = other.gameObject.transform.GetComponent<SoundCollider>().getSound();
            soundSource.PlayOneShot(clipToPlay);
            other.gameObject.SetActive(false);

        }
    }

    public AudioClip getAudioClip()
    {
        return clipToPlay;
    }

    public bool getBool()
    {
        return newSound;
    }

}
