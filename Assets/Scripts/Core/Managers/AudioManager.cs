using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour, IAudioManager
{
    private AudioSource _musicSource;
    private AudioSource _sfxSource;
    private bool _isInitialized = false;

    void Start()
    {
        if (_isInitialized) return;

        _musicSource = gameObject.AddComponent<AudioSource>();
        _sfxSource = gameObject.AddComponent<AudioSource>();

        _isInitialized = true;
        Debug.Log("AudioManager initialized");
    }

    public void PlaySound(string soundName)
    {
        if (!_isInitialized) return;

        var clip = Resources.Load<AudioClip>($"Audio/SFX/{soundName}");
        if (clip != null)
        {
            _sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayMusic(string musicName, float startOffset = 0, float? endOffset = null, bool onLoop = false, float volume = 1.0f)
    {
        if (!_isInitialized) return;

        var clip = Resources.Load<AudioClip>($"Audio/Music/{musicName}");

        if (clip != null)
        {
            _musicSource.clip = clip;
            _musicSource.time = startOffset;
            _musicSource.volume = volume;
            _musicSource.loop = onLoop;
            _musicSource.Play();
            if (endOffset.HasValue)
            {
                StartCoroutine(StopMusicAfterDuration(endOffset.Value - startOffset));
            }
        }
    }

    public void StopMusic()
    {
        if (!_isInitialized) return;
        _musicSource.Stop();
    }

    private IEnumerator StopMusicAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        StopMusic();
    }
}
