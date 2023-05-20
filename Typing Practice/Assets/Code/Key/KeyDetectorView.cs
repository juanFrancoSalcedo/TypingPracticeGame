using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using DG.Tweening;

public partial class KeyboardDetector
{
    [System.Serializable]
    public class KeyDetectorView
    {
        [SerializeField] private CurvedText m_curve = null;
        [SerializeField] private RectTransform incorrect = null;
        [SerializeField] private RectTransform correct = null;
        [SerializeField] private Text m_text = null;

        public void DisplayKey(KeyboardDetector detector) 
        {
            m_curve.CurveMultiplier = -20;
            DOTween.To(() => m_curve.CurveMultiplier, x => m_curve.CurveMultiplier = x, 0, KeyboardDetector.animationTimes).
                SetEase(Ease.OutBack);
            m_text.text = NormalizeKey(detector.CurrentKey.ToString()).ToString();
        }

        public void DisplayCorrect(bool isCorrect)
        {
            incorrect.anchoredPosition = Vector2.one * 5000;
            correct.anchoredPosition = Vector2.one * 5000;
            Sequence seq = DOTween.Sequence();

            if (isCorrect)
            {   
                seq.Append(correct.DOAnchorPos(Vector2.zero, 0.1f));
                seq.Append(correct.DOAnchorPos(Vector2.one * 5000, 0.1f).SetDelay(3f));
            }
            else
            {
                seq.Append(incorrect.DOAnchorPos(Vector2.zero, 0.1f));
                seq.Append(incorrect.DOAnchorPos(Vector2.one * 5000, 0.1f).SetDelay(3f));
            }
        }
    }
}
