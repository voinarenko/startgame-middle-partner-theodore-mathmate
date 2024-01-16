using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Генератор задания.
    /// </summary>
    public class TaskGenerator : MonoBehaviour
    {
        private GameController GameController => GetComponent<GameController>();

        /// <summary>
        /// Метод получения нового задания
        /// </summary>
        /// <returns>строка с заданием</returns>
        public KeyValuePair<string, int> GetNewTask()
        {
            var taskString = "";

            var numbers = GetNumbers();
            var operations = GetOperations();

            for (var i = 0; i < operations.Count; i++) taskString += $"{numbers[i]} {operations[i]} ";

            taskString += $"{numbers[^1]}";
            var answer = int.Parse(new System.Data.DataTable().Compute(taskString, "").ToString());
            taskString += " =";

            return new KeyValuePair<string, int>(taskString, answer);
        }

        /// <summary>
        /// Метод генерации списка случайных чисел
        /// </summary>
        /// <returns>список случайных чисел</returns>
        private List<int> GetNumbers()
        {
            var result = new List<int>();
            for (var i = 0; i <= GameController.GameData.StageMultipleSeven; i++) result.Add(GetRandomNumber());
            return result;
        }

        /// <summary>
        /// Метод генерации списка случайных операций
        /// </summary>
        /// <returns>список случайных операций</returns>
        private List<string> GetOperations()
        {
            var result = new List<string>();
            for (var i = 0; i < GameController.GameData.StageMultipleSeven; i++) result.Add(GetRandomOperation());
            return result;
        }

        /// <summary>
        /// Метод генерации случайного числа
        /// </summary>
        /// <returns>случайное число</returns>
        public static int GetRandomNumber() => new System.Random().Next(-10, 11);

        /// <summary>
        /// Метод генерации случайной операции
        /// </summary>
        /// <returns>случайная операция</returns>
        private static string GetRandomOperation()
        {
            var result = "";
            var number = new Random().Next(2);
            result = number switch
            {
                0 => "-",
                1 => "+",
                _ => result
            };

            return result;
        }
    }
}