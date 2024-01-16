using Assets.Scripts.Screens;
using UnityEngine;

namespace Assets.Scripts.Game
{
    /// <summary>
    /// Вид.
    /// </summary>
    public abstract class View : MonoBehaviour
    {
        protected static GameController GameController => FindAnyObjectByType<GameController>(FindObjectsInactive.Include);
        protected static PlayScreen GameScreen => FindAnyObjectByType<PlayScreen>(FindObjectsInactive.Include);
        protected static MenuScreen MenuScreen => FindAnyObjectByType<MenuScreen>(FindObjectsInactive.Include);
    }
}