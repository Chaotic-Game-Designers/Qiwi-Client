using DG.Tweening;
using TMPro;
using UnityEngine;
using Zenject;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValue;
    [Inject] private IGameManager _gameManager;

    public void Initialize(int score)
    {
        DOTween.To(() => 0, x =>
        {
            scoreValue.text = $"{x} %";
        }, score, 1f)
        .SetEase(Ease.OutQuad);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            _gameManager.ShowMainMenu();
        }
    }
}