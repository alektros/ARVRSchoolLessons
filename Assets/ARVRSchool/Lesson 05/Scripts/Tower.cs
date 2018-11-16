using System;

namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class Tower : MonoBehaviour
    {
        [SerializeField] private Color        _defaultColor;
        [SerializeField] private Color        _errorColor;
        
        
        [SerializeField] private ColorChanger _colorChanger;
        
        
        public Action<Tower, int> OnHealthPointChaged = delegate(Tower i, int arg2) {  };
        
        public Action<Tower> OnStateChanged = delegate(Tower tower) {  };

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
            // 
            //
            //
            int currentHP = 12;
            OnHealthPointChaged(this, currentHP);
        }
    }
}