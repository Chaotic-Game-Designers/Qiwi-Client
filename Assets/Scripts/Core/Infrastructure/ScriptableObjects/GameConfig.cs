using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Qiwi/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float loadingScreenMinDuration = 1f;
    public float maxTimeToAnswer = 20f;
    public string backgroundMusic = "BackgroundMusic";
    //public string loadingSoundEffect = "BackgroundMusic";
    public string buttonClickSound = "ButtonClickSound";
}