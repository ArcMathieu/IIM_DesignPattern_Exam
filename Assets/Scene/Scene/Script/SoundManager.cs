using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource EffectsSource;
    [SerializeField] AudioSource MusicSource;

    // Start is called before the first frame update

    public void Play(AudioClip clip)
    {
        EffectsSource.PlayOneShot(clip, 0.7F);
    }
    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    // Play a random clip from an array, and randomize the pitch slightly.
    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        EffectsSource.PlayOneShot(clips[randomIndex], 0.7f);
    }
}
