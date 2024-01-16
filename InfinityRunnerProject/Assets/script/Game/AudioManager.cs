using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    
    [SerializeField] AudioClip jumpClip;
    [SerializeField] [Range(0f, 1f)] float jumpClipVolume = 1f;

    
    [SerializeField] AudioClip coinClip;
    [SerializeField] [Range(0f, 1f)] float coinClipVolume;

    public void PlayShootingClip()
    {
        if (jumpClip != null)
        {
            PlayClip(jumpClip, jumpClipVolume);
        }
        
    }

    public void CasualExplosion()
    {
        if (coinClip != null)
        {
            PlayClip(coinClip, coinClipVolume);
        }
        
    }

    void PlayMusic()
    {
        audioSource.mute = false;
    }
   void StopMusicClip()
    {
        audioSource.mute = true;
    }

    void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
