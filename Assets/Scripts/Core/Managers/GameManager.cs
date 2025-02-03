using System.Threading.Tasks;
using Unity.Services.Analytics;
using UnityEngine;
using Zenject;

public class GameManager : IGameManager
{
    private readonly IGameAnalyticsService _analyticsService;
    private readonly IAudioManager _audioManager;
    private readonly IQuestionRepository _questionRepository;
    private readonly IScoreCalculator _scoreCalculator;
    private readonly GameConfig _gameConfig;

    private LoadingScreenPanel _loadingPanel;
    private MainMenuPanel _mainMenuPanel;
    private QuestionPanel _questionPanel;
    private ScorePanel _scorePanel;

    private MusicQuestion currentQuestion;

    [Inject]
    public GameManager(
        IGameAnalyticsService analyticsService,
        IAudioManager audioManager,
        IQuestionRepository questionRepository,
        IScoreCalculator scoreCalculator,
        GameConfig gameConfig)
    {
        _analyticsService = analyticsService;
        _audioManager = audioManager;
        _questionRepository = questionRepository;
        _scoreCalculator = scoreCalculator;
        _gameConfig = gameConfig;

        InitializePanels();
    }

    private void InitializePanels()
    {
        _loadingPanel = GameObject.FindObjectOfType<LoadingScreenPanel>(true);
        _mainMenuPanel = GameObject.FindObjectOfType<MainMenuPanel>(true);
        _questionPanel = GameObject.FindObjectOfType<QuestionPanel>(true);
        _scorePanel = GameObject.FindObjectOfType<ScorePanel>(true);

        if (_loadingPanel == null || _mainMenuPanel == null ||
            _questionPanel == null || _scorePanel == null)
        {
            Debug.LogError("One or more required panels not found in the scene!");
        }

        SetAllPanelsInactive();
    }

    private void SetAllPanelsInactive()
    {
        _loadingPanel?.gameObject.SetActive(false);
        _mainMenuPanel?.gameObject.SetActive(false);
        _questionPanel?.gameObject.SetActive(false);
        _scorePanel?.gameObject.SetActive(false);
    }

    public async Task StartGame()
    {
        _analyticsService.LogGameStart();
        //await ShowLoadingScreen();
        await _questionRepository.InitializeQuestions();
        ShowMainMenu();
    }

    public async Task ShowLoading()
    {
        SetAllPanelsInactive();
        _loadingPanel.gameObject.SetActive(true);
        await Task.Delay(Mathf.RoundToInt(_gameConfig.loadingScreenMinDuration * 1000));
    }

    //private async Task ShowLoadingScreen()
    //{
    //    SetAllPanelsInactive();
    //    _loadingPanel.gameObject.SetActive(true);
    //    //_audioManager.PlaySound(_gameConfig.loadingSoundEffect);
    //    await Task.Delay(Mathf.RoundToInt(_gameConfig.loadingScreenMinDuration * 1000));
    //    _loadingPanel.gameObject.SetActive(false);
    //}

    public void ShowMainMenu()
    {
        SetAllPanelsInactive();
        _mainMenuPanel.gameObject.SetActive(true);
        _audioManager.PlayMusic(_gameConfig.backgroundMusic);
    }

    public void OnPlayButtonClicked()
    {
        _audioManager.PlaySound(_gameConfig.buttonClickSound);
        StartQuestion();
    }

    private void StartQuestion()
    {
        currentQuestion = _questionRepository.GetRandomQuestion();
        ShowQuestionUI(currentQuestion);
        _audioManager.PlayMusic(currentQuestion.musicFileName,
            currentQuestion.startOffset, currentQuestion.endOffset);
    }

    private void ShowQuestionUI(MusicQuestion question)
    {
        SetAllPanelsInactive();
        _questionPanel.gameObject.SetActive(true);
        _questionPanel.Initialize(question);
    }

    public void OnAnswerSelected(int answerIndex, float timeToAnswer)
    {
        _audioManager.StopMusic();
        var score = _scoreCalculator.CalculateScore(
            currentQuestion.correctAnswerIndex == answerIndex,
            timeToAnswer
        );

        ShowScoreUI(score);
    }

    private void ShowScoreUI(int score)
    {
        SetAllPanelsInactive();
        _scorePanel.gameObject.SetActive(true);
        _scorePanel.Initialize(score);
    }
}
