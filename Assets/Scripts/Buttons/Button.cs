using Assets.Scripts.Game;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Buttons
{
    /// <summary>
    /// Кнопка.
    /// </summary>
    public abstract class Button : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        protected static GameView GameView => FindAnyObjectByType<GameView>(FindObjectsInactive.Include);
        protected static MenuView MenuView => FindAnyObjectByType<MenuView>(FindObjectsInactive.Include);

        private AudioClip _buttonPress;
        private AudioClip _buttonRelease;
        private AudioSource _audioSource;
        protected AudioMixer Mixer;

        private void Start()
        {
            // ReSharper disable twice StringLiteralTypo
            _buttonPress = Resources.Load<AudioClip>("sounds/eventpress");
            _buttonRelease = Resources.Load<AudioClip>("sounds/eventunpress");
            Mixer = Resources.Load<AudioMixer>("AudioMixer");
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.outputAudioMixerGroup = Mixer.FindMatchingGroups("Effects")[0];
        }

        public abstract void OnPointerClick(PointerEventData eventData);

        public void OnPointerDown(PointerEventData eventData) => _audioSource.PlayOneShot(_buttonPress);

        public void OnPointerUp(PointerEventData eventData) => _audioSource.PlayOneShot(_buttonRelease);
    }
}