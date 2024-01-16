using Assets.Scripts.Screens;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка паузы.
    /// </summary>
    public class PauseButton : Button
    {
        private static Screens.Screen Screen => FindAnyObjectByType<PauseScreen>(FindObjectsInactive.Include);

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (Screen.gameObject.activeSelf)
            {
                Screen.CloseScreen();
            }
            else
            {
                Screen.gameObject.SetActive(true);
                Screen.OpenScreen();
            }
        }
    }
}