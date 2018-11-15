namespace Ru.Funreality.ARVRLessons.Lesson05
{
    using UnityEngine;

    public class ColorChanger : MonoBehaviour
    {
        public void SetColor(Color color)
        {
            GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}