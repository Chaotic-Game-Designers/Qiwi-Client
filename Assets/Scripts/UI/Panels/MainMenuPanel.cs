using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [Inject] private IGameManager _gameManager;

    private void Start()
    {
        playButton.transform
            .DOScale(1.1f, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);

        playButton.onClick.AddListener(() => _gameManager.OnPlayButtonClicked());
    }
}
