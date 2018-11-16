namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Компонент предоставляет возможность смены цвета персонажа
    /// </summary>
    public class ColorChanger : MonoBehaviour
    {
        /// <summary>
        /// Меняет цвет материала
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}