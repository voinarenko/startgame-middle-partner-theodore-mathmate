using System;
using System.Collections.Generic;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Данные игры.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public string Name { get; set; } = "anonymous"; // имя игрока
        public int StartLevel => 1; // начальный уровень игры
        public int Level { get; set; } = 1; // уровень игры
        public int StartScore => 0; // начальное количество очков
        public int Score { get; set; } // количество очков
        public int LastScore { get; set; } // последний результат
        public int StartStageMultipleSeven => 1; // начальный этап игры, кратный 7
        public int StageMultipleSeven { get; set; } = 1; // этап игры, кратный 7
        public int StartStageMultipleTen => 0; // начальный этап игры, кратный 10
        public int StageMultipleTen { get; set; } // этап игры, кратный 10
        public float InitialDuration { get; set; } = 11; // начальное время игры
        public float Penalty { get; set; } = 7; // штраф
        public int ScoreBonus { get; set; } = 5; // награда за правильный ответ
        public float TimeBonus { get; set; } = 5; // дополнительное время
        public List<KeyValuePair<string, int>> TopFive { get; set; } = new(); // список пяти лучших игроков
    }
}