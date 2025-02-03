using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenPanel : MonoBehaviour
{
    [SerializeField] private Image logoImage;

    private void Start()
    {
        logoImage.color = new Color(logoImage.color.r, logoImage.color.g, logoImage.color.b, 0);

        logoImage.DOFade(1f, 1f)
            .SetEase(Ease.InOutQuad);
    }
}
