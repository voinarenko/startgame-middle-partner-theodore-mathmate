using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Screens
{
    /// <summary>
    /// Экран.
    /// </summary>
    public abstract class Screen : MonoBehaviour
    {
        protected const float OpenTime = 0.1f;
        private const float CloseTime = 0.1f;

        /// <summary>
        /// Метод открытия окна
        /// </summary>
        public virtual void OpenScreen()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, OpenTime);
        }

        /// <summary>
        /// Метод закрытия окна
        /// </summary>
        public virtual void CloseScreen() => transform.DOScale(Vector3.zero, CloseTime).OnComplete(() => gameObject.SetActive(false));
    }
}