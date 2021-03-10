using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollider : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;
    public AudioClip getSound()
    {
        return sound;
    }
}
