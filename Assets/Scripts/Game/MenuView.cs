using TMPro;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Вид меню.
    /// </summary>
    public class MenuView : View
    {
        [SerializeField] private TMP_Text _resultsText; // результаты предыдущей игры
        [SerializeField] private TMP_Text _playButtonLabel; // надпись на кнопке игры
        [SerializeField] private TMP_Text _quitButtonLabel; // надпись на кнопке выхода
        [SerializeField] private TMP_Text _theodoreLabel; // название игры первая строка
        [SerializeField] private TMP_Text _mathMateLabel; // название игры вторая строка
        [SerializeField] private TMP_InputField NameText; // поле ввода имени

        [SerializeField] private TMP_Text[] _topNames; // имена игроков
        [SerializeField] private TMP_Text[] _topScores; // очки игроков

        private void Start()
        {
            _playButtonLabel.text = "Играть";
            _quitButtonLabel.text = "Выход";
            _theodoreLabel.text = "Фёдор";
            _mathMateLabel.text = "математик";
            NameText.text = GameController.GameData.Name;
            UpdateView();
        }

        private void OnEnable() => UpdateView();

        /// <summary>
        /// Метод запуска новой игры
        /// </summary>
        public void StartNewGame()
        {
            GameController.ResetTimer();
            GameScreen.gameObject.SetActive(true);
            GameScreen.OpenScreen();
            MenuScreen.CloseScreen();
            GameController.GameData.Name = NameText.text;
            GameController.SetNewTask();
        }

        /// <summary>
        /// Метод обновления данных
        /// </summary>
        private void UpdateView()
        {
            _resultsText.text = $"Ваш результат - {GameController.GameData.LastScore}";
            var topFive = GameController.GameData.TopFive;
            for (var i = 0; i < topFive.Count; i++)
            {
                _topNames[i].text = topFive[i].Key;
                _topScores[i].text = topFive[i].Value.ToString();
            }
        }
    }
}