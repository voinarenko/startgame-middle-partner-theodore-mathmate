using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.Screens
{
    /// <summary>
    /// Экран паузы.
    /// </summary>
    public class PauseScreen : Screen
    {
        public override void OpenScreen()
        {
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, OpenTime).OnComplete(() => Time.timeScale = 0);
        }

        public override void CloseScreen()
        {
            Time.timeScale = 1;
            base.CloseScreen();
        }
    }
}