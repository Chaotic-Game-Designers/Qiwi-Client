using System.Threading.Tasks;

public interface IGameManager
{
    Task ShowLoading();
    Task StartGame();
    public void ShowMainMenu();
    void OnPlayButtonClicked();
    void OnAnswerSelected(int answerIndex, float timeToAnswer);
}