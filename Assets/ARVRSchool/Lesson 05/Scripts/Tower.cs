using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    /// <summary>
    /// Компонент, управляющий башней
    /// </summary>
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Color        _defaultColor;
        [SerializeField] private Color        _errorColor;
        [SerializeField] private ColorChanger _colorChanger;
        /// <summary>
        /// Вызывается, когда изменяется количество HealthPoints
        /// </summary>
        public Action<Tower, int> OnHealthPointChanged = delegate { };
        /// <summary>
        /// Вызывается, когда изменяется состояние башни
        /// </summary>
        public Action<Tower> OnStateChanged = delegate { };

        public void SetDefaultColor()
        {
            _colorChanger.SetColor(_defaultColor);
        }

        public void SetErrorColor()
        {
            _colorChanger.SetColor(_errorColor);
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        private void LooseHealth()
        {
            int currentHP = 12;
            OnHealthPointChanged(this, currentHP);
        }
    }
}