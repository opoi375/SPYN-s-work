using UnityEngine;
using UnityEngine.Events;

namespace Script.FameWork.UI
{
    /// <summary>
    /// 面板基类
    /// 所有面板类需继承自本类，注意：gameObject.name 应与面板类名保持一致
    /// </summary>
    public class PanelBase : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("淡入淡出的速度")]
        private float fadeSpeed;
        private bool toShow;
        private bool toHide;

        private CanvasGroup canvasGroup;
        private UnityAction action;
    
        protected virtual void Awake()
        {
            if(!TryGetComponent<CanvasGroup>(out canvasGroup))
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        protected virtual void Update()
        {
            if(toShow)
            {
            
                canvasGroup.alpha += Time.unscaledDeltaTime * fadeSpeed;
                if(canvasGroup.alpha >=1 ) toShow = false;
            }

            if (!toHide) return;
            canvasGroup.alpha -= Time.unscaledDeltaTime * fadeSpeed;
            if (!(canvasGroup.alpha <= 0)) return;
            toHide = false;
            action?.Invoke();
        }

        /// <summary>
        /// 隐藏自身
        /// </summary>
        /// <param name="action">隐藏完成后的回调事件</param>
        public void HideMe(UnityAction action = null)
        {
            toHide = true;
            this.action = action;
            canvasGroup.alpha = 1;
        }
        /// <summary>
        /// 显示自身
        /// </summary>
        public void ShowMe()
        {
        
            toShow = true;
            canvasGroup.alpha = 0;
        }
    }
}
