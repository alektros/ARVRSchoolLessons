namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class Tower : MonoBehaviour
    {
        [SerializeField] private Color        _defaultColor;
        [SerializeField] private Color        _errorColor;
        [SerializeField] private ColorChanger _colorChanger;

        public void SetDefaultColor()
        {
            _colorChanger.SetColor(_defaultColor);
        }

        public void SetErrorColor()
        {
            _colorChanger.SetColor(_errorColor);
        }
    }
}