using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        public GameData GameData;
        private GameView GameView => GetComponent<GameView>();
        private TopFive TopFive => GetComponent<TopFive>();
        private TaskGenerator TaskGenerator => GetComponent<TaskGenerator>();
        private KeyValuePair<string, int> _task; // задание
        private float _timer; // таймер
        private const string AnimationRight = "Right"; // анимация правильного ответа
        private const string AnimationWrong = "Wrong"; // анимация неправильного ответа

        private void Start()
        {
            ResetTimer();
            SetNewTask();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            GameView.DisplayTime(_timer, GameData.InitialDuration);
            if (!(_timer <= 0)) return;
            GameOver();
            ResetTimer();
        }

        /// <summary>
        /// Метод завершения игры
        /// </summary>
        private void GameOver()
        {
            TopFive.AddToTop(new KeyValuePair<string, int>(GameData.Name, GameData.Score));
            GameData.LastScore = GameData.Score;
            ResetData();
            GameView.GameOver();
        }

        /// <summary>
        /// Метод проверки ответа
        /// </summary>
        /// <param name="answer">строка с ответом</param>
        public void CheckAnswer(string answer)
        {
            if (_task.Value == int.Parse(answer))
            {
                GameView.SetAnimation(AnimationRight);
                GameData.Level++;
                GameData.Score += GameData.ScoreBonus + GameData.StageMultipleTen * 2;
                _timer += GameData.TimeBonus - GameData.StageMultipleTen;
                SetNewTask();
                GameView.UpdateView();
                CheckLevel();
            }
            else
            {
                GameView.SetAnimation(AnimationWrong);
                _timer -= GameData.Penalty;
            }
        }
        
        /// <summary>
        /// Метод проверки уровня.
        /// </summary>
        private void CheckLevel()
        {
            if (GameData.Level % 7 == 0) GameData.StageMultipleSeven++;
            if (GameData.Level % 10 == 0) GameData.StageMultipleTen++;
        }

        /// <summary>
        /// Метод установки нового задания
        /// </summary>
        public void SetNewTask()
        {
            _task = TaskGenerator.GetNewTask();
            GameView.ShowTask(_task.Key);

            var answers = new List<int> { _task.Value };
            for (var i = 1; i < GameView.ButtonsCount; i++)
            {
                var random = TaskGenerator.GetRandomNumber();
                if (!answers.Contains(random)) answers.Add(random);
                else i--;
            }

            GameView.ShowAnswers(answers);
        }

        /// <summary>
        /// Метод сброса таймера
        /// </summary>
        public void ResetTimer() => _timer = GameData.InitialDuration;

        /// <summary>
        /// Метод сброса данных
        /// </summary>
        private void ResetData()
        {
            GameData.Level = GameData.StartLevel;
            GameData.Score = GameData.StartScore;
            GameData.StageMultipleSeven = GameData.StartStageMultipleSeven;
            GameData.StageMultipleTen = GameData.StartStageMultipleTen;
        }
    }
}