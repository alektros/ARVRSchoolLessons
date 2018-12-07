namespace Ru.Funreality.ARVRLessons.Lesson08
{
    using UnityEngine;

    public class CustomPropertySample : MonoBehaviour
    {
        public  Color    TestColor;
        private Material _targetMaterial;
        public  void     OnCustomPropertyAnimFinish(int param) { Debug.Log("OnCustomPropertyAnimFinish " + param); }

        private void Start()
        {
            _targetMaterial = GetComponent<MeshRenderer>().material;
        }

        private void Update() { _targetMaterial.SetColor("_Color", TestColor); }
    }
}