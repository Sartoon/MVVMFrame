using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace MVVM
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseState : MonoBehaviour
    {
        private const float FADE_DURATION = 0.3F;
        private const float ORIGINAL_SCALE = 0.8F;

        private CanvasGroup _canvasGroup;
        private EUIType _uiType;
        public MVVM.EUIType UIType
        {
            get { return _uiType; }
            set { _uiType = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public virtual void OnEnter(object param = null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            OnShow(param);
        }

        public virtual void OnShow(object param=null)
        {
            gameObject.SetActive(true);
        }

        public virtual void OnExit()
        {
            OnHide();
            DestroySelf();
        }

        public virtual void OnHide()
        {
            gameObject.SetActive(false);
        }

        public virtual void DestroySelf()
        {
            UIManager.GetInstance().DestroySingleUI(_uiType);
        }

        public Tweener BeginEnterTween()
        {
            Tweener tweener = transform.DOScale(Vector3.one * ORIGINAL_SCALE, FADE_DURATION).From();
            StartCoroutine(BlockTouchForTween(tweener));
            return DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 0f, FADE_DURATION).From();
        }

        public Tweener BeginExitTween()
        {
            Tweener tweener = transform.DOScale(Vector3.one * ORIGINAL_SCALE, FADE_DURATION).From();
            StartCoroutine(BlockTouchForTween(tweener));
            return DOTween.To(() => _canvasGroup.alpha, x => _canvasGroup.alpha = x, 0f, FADE_DURATION);
        }
        private IEnumerator BlockTouchForTween(Tweener tweener)
        {
            DisableTouch();
            yield return tweener.WaitForCompletion();
            EnabelTouch();
        }


        public void DisableTouch()
        {
            _canvasGroup.blocksRaycasts = false;
        }

        public void EnabelTouch()
        {
            _canvasGroup.blocksRaycasts = true;
        }
    }
}