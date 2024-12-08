using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundManager
{
    void PlayMusic(AudioClip clip, float volume = 1.0f);
    void PlayEffect(AudioClip clip, float volume = 1.0f);
    void StopMusic();
    void SetMusicVolume(float volume);
    void SetEffectsVolume(float volume);
}

public class SoundManager : MonoBehaviour, ISoundManager
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;

    public void PlayMusic(AudioClip clip, float volume = 1.0f)
    {
        _musicSource.clip = clip;
        _effectsSource.volume = volume;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayEffect(AudioClip clip, float volume = 1.0f)
        => _effectsSource.PlayOneShot(clip, volume);

    public void StopMusic()
        => _musicSource.Stop();

    public void SetMusicVolume(float volume)
        => _musicSource.volume = volume;

    public void SetEffectsVolume(float volume)
        => _effectsSource.volume = volume;
}
