using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Топ 5 лучших игроков.
    /// </summary>
    public class TopFive : MonoBehaviour
    {
        private GameController GameController => GetComponent<GameController>();

        public void AddToTop(KeyValuePair<string, int> data)
        {
            var currentTop = GameController.GameData.TopFive;
            currentTop.Add(data);
            var newTop = currentTop.OrderByDescending(i => i.Value).ToList();
            if (newTop.Count > 5) newTop.RemoveAt(5);
            GameController.GameData.TopFive = newTop;
        }
    }
}