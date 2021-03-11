using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] footstepSounds;
    [SerializeField]
    private AudioSource footstepAudioSource;
    [SerializeField]
    private float footstepDistance = 0.3f;
    private float footstepCounter = 0;
    private float timeHolder = 0;
    private int randomNumber;
    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private Vector2 footstepSoundPitchRange = new Vector2 (0.85f,1);
    [SerializeField]
    private Vector2 footstepSoundVolumeRange = new Vector2(0.65f, 1);

    private void Awake()
    {
        playerController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(playerController.velocity.sqrMagnitude > 1)
        {
            timeHolder += Time.deltaTime;
            footstepCounter = timeHolder * playerController.velocity.sqrMagnitude;
            if(footstepCounter >= footstepDistance)
            {
                timeHolder = 0;
                randomNumber = Random.Range(0, footstepSounds.Length - 1);
                footstepAudioSource.pitch = Random.Range(footstepSoundPitchRange.x, footstepSoundPitchRange.y);
                footstepAudioSource.volume = Random.Range(footstepSoundVolumeRange.x, footstepSoundVolumeRange.y);
                footstepAudioSource.PlayOneShot(footstepSounds[randomNumber]);
            }
        }
    }
}
