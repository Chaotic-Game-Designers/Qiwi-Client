public interface IAudioManager
{
    void PlaySound(string soundName);
    void PlayMusic(string musicName, float startOffset = 0, float? endOffset = null, bool onLoop = false, float volume = 1.0f);
    void StopMusic();
}