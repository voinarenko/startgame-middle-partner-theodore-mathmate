using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка выхода.
    /// </summary>
    public class QuitButton : Button
    {
        public override void OnPointerClick(PointerEventData eventData) => Application.Quit();
    }
}