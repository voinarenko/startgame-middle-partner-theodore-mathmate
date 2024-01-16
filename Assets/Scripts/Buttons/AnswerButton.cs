using Assets.Scripts.Game;
using TMPro;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка ответа.
    /// </summary>
    public class AnswerButton : Button
    {
        private TMP_Text AnswerText => GetComponentInChildren<TMP_Text>(); // значение ответа

        public override void OnPointerClick(PointerEventData eventData) => GameView.ReturnAnswer(AnswerText.text);
    }
}