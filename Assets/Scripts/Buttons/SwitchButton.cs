using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка переключения.
    /// </summary>
    public class SwitchButton : Button
    {
        [SerializeField] protected string Source; // источник для переключения
        private Image Image => GetComponent<Image>();
        [SerializeField] protected Sprite[] Sprites; // массив изображений

        public override void OnPointerClick(PointerEventData eventData)
        {
            Mixer.GetFloat(Source, out var volume);
            if (volume != -80)
            {
                Mixer.SetFloat(Source, -80);
                Image.sprite = Sprites[0];
            }
            else
            {
                Mixer.SetFloat(Source, 0);
                Image.sprite = Sprites[1];
            }
        }
    }
}