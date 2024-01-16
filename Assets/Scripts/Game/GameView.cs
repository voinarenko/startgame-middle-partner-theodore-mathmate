using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Вид игры.
    /// </summary>
    public class GameView : View
    {
        [SerializeField] private Animator _theodoreAnimator;

        [SerializeField] private TMP_Text _levelLabel; // подпись уровня
        [SerializeField] private TMP_Text _levelData; // значение уровня
        [SerializeField] private TMP_Text _scoreLabel; // подпись очков
        [SerializeField] private TMP_Text _scoreData; // количество очков
        [SerializeField] private TMP_Text _taskText; // текст задания
        [SerializeField] private Slider _timerSlider; // ползунок таймера
        [SerializeField] private TMP_Text _timerText; // таймер
        [SerializeField] private TMP_Text[] _answerButtonText; // кнопки ответов

        public int ButtonsCount => _answerButtonText.Length; // количество вариантов ответов

        private void Start()
        {
            _levelLabel.text = "Уровень";
            _scoreLabel.text = "Очки";
            UpdateView();
        }

        private void OnEnable() => UpdateView();

        /// <summary>
        /// Метод вызова анимации ответа
        /// </summary>
        /// <param name="answer">имя триггера</param>
        public void SetAnimation(string answer) => _theodoreAnimator.SetTrigger(answer);

        /// <summary>
        /// Метод завершения игры
        /// </summary>
        public void GameOver()
        {
            MenuScreen.gameObject.SetActive(true);
            MenuScreen.OpenScreen();
            UpdateView();
            GameScreen.CloseScreen();
        }

        /// <summary>
        /// Метод, возвращающий ответ
        /// </summary>
        /// <param name="answer">строка с ответом</param>
        public static void ReturnAnswer(string answer) => GameController.CheckAnswer(answer);

        /// <summary>
        /// Метод отображения задания
        /// </summary>
        /// <param name="text">строка с заданием</param>
        public void ShowTask(string text) => _taskText.text = text;

        /// <summary>
        /// Метод отображения ответов
        /// </summary>
        /// <param name="answers">список ответов</param>
        public void ShowAnswers(List<int> answers)
        {
            var assigned = new List<int>();
            for (var i = 0; i < ButtonsCount; i++)
            {
                var index = new System.Random().Next(ButtonsCount);
                if (!assigned.Contains(index))
                {
                    _answerButtonText[index].text = answers[i].ToString();
                    assigned.Add(index);
                }
                else i--;
            }
        }

        /// <summary>
        /// Метод обновления данных
        /// </summary>
        public void UpdateView()
        {
            _levelData.text = $"{GameController.GameData.Level}";
            _scoreData.text = $"{GameController.GameData.Score}";
        }

        /// <summary>
        /// Метод форматированного вывода времени
        /// </summary>
        /// <param name="time">текущее время</param>
        /// <param name="maxTime">начальное время игры</param>
        public void DisplayTime(float time, float maxTime)
        {
            if (time < 0) time = 0;

            var minutes = Mathf.FloorToInt(time / 60);
            var seconds = Mathf.FloorToInt(time % 60);

            _timerText.text = $"{minutes:0}:{seconds:00}";
            _timerSlider.value = time / maxTime;
        }

    }
}