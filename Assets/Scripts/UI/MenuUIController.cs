using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Zenject;

public class MenuUIController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private RectTransform mainMenuPanel;
    [SerializeField] private RectTransform settingsPanel;
    [SerializeField] private RectTransform playPanel;

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button backButton;

    private IGameAnalyticsService _analyticsService;
    private ISoundManager _soundManager;
    private MenuManager _menuManager;

    [Inject]
    private void Construct(
        IGameAnalyticsService analyticsService,
        ISoundManager soundManager,
        MenuManager menuManager)
    {
        _analyticsService = analyticsService;
        _soundManager = soundManager;
        _menuManager = menuManager;
    }

    private void Start()
    {
        InitializeButtons();
        ShowMainMenu();
    }

    private void InitializeButtons()
    {
        playButton.onClick.AddListener(() => {
            ShowPlayPanel();
            _analyticsService.LogButtonClick("play");
        });

        settingsButton.onClick.AddListener(() => {
            ShowSettingsPanel();
            _analyticsService.LogButtonClick("settings");
        });

        startGameButton.onClick.AddListener(() => {
            _menuManager.StartGame();
            _analyticsService.LogButtonClick("start_game");
        });

        backButton.onClick.AddListener(() => {
            ShowMainMenu();
            _analyticsService.LogButtonClick("back");
        });
    }

    private void ShowMainMenu()
    {
        AnimatePanel(mainMenuPanel, true);
        AnimatePanel(settingsPanel, false);
        AnimatePanel(playPanel, false);
        _analyticsService.LogMenuOpen("main");
    }

    private void ShowPlayPanel()
    {
        AnimatePanel(mainMenuPanel, false);
        AnimatePanel(settingsPanel, false);
        AnimatePanel(playPanel, true);
        _analyticsService.LogMenuOpen("play");
    }

    private void ShowSettingsPanel()
    {
        AnimatePanel(mainMenuPanel, false);
        AnimatePanel(settingsPanel, true);
        AnimatePanel(playPanel, false);
        _analyticsService.LogMenuOpen("settings");
    }

    private void AnimatePanel(RectTransform panel, bool show)
    {
        panel.gameObject.SetActive(true);

        if (show)
        {
            panel.DOScale(Vector3.one, 0.3f)
                .From(Vector3.zero)
                .SetEase(Ease.OutBack);
            panel.DOFade(1f, 0.3f)
                .From(0f);
        }
        else
        {
            panel.DOScale(Vector3.zero, 0.3f)
                .SetEase(Ease.InBack)
                .OnComplete(() => panel.gameObject.SetActive(false));
            panel.DOFade(0f, 0.3f);
        }
    }
}