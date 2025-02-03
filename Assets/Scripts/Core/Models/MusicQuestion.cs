[System.Serializable]
public class MusicQuestion
{
    public string questionText;
    public string[] possibleAnswers;
    public int correctAnswerIndex;
    public string musicFileName;
    public float startOffset;
    public float endOffset;
}