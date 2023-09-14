using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace KingOfHill
{
    public abstract class AdvancedUI : MonoBehaviour
    {
        protected CanvasGroup _canvasGroup => GetComponent<CanvasGroup>();

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void ShowPanel(TweenCallback action)
        {
            action?.Invoke();
            _canvasGroup.alpha = 0;
            SetActive(true);
            DOTween.Sequence()
                .SetUpdate(true)
                .AppendInterval(1)
                .Append(_canvasGroup.DOFade(1, 0.5f));
        }

        protected void ClosePanel(Button button, TweenCallback action)
        {
            DOTween.Sequence()
                .SetUpdate(true)
                .Append(button.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), 0.5f, 5, 1.5f))
                .Append(_canvasGroup.DOFade(0, 0.5f))
                .OnComplete(() => 
                { 
                    SetActive(false); 
                    action?.Invoke(); 
                });
        }
    }
} 


