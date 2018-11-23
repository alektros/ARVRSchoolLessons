using UnityEngine;

namespace Ru.Funreality.ARVRLessons.Lesson06.EnumerableData
{
    public class DataView<T> : MonoBehaviour where T : Data
    {
        public         T    Data                    { get; private set; }
        public virtual void Bind(T        data)     { Data = data; }
        public         void Activate(bool activate) { gameObject.SetActive(activate); }

        public void SetParent(RectTransform parent)
        {
            GetComponent<RectTransform>().SetParent(parent, false);
        }
    }
}