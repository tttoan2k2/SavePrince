using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class LoadingDotsDOTween : MonoBehaviour
{
    public Text loadingText;

    private Sequence dotSequence;

    void Start()
    {
        AnimateDots();
    }

    void AnimateDots()
    {
        dotSequence = DOTween.Sequence().SetLoops(-1);

        dotSequence.AppendCallback(() => loadingText.text = "Loading")
                   .AppendInterval(0.3f)
                   .AppendCallback(() => loadingText.text = "Loading.")
                   .AppendInterval(0.3f)
                   .AppendCallback(() => loadingText.text = "Loading..")
                   .AppendInterval(0.3f)
                   .AppendCallback(() => loadingText.text = "Loading...")
                   .AppendInterval(0.3f);
    }

    void OnDestroy()
    {
        dotSequence.Kill();
    }
}
