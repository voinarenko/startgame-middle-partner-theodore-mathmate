using Assets.Scripts.Game;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка начала игры.
    /// </summary>
    public class PlayButton : Button
    {
        public override void OnPointerClick(PointerEventData eventData) => MenuView.StartNewGame();
    }
}