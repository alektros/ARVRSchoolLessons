namespace Ru.Funreality.ARVRLessons.Lesson08
{
    using UnityEngine;

    public class MechanimSample : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public                   void     Jump()  { _animator.SetTrigger("Jumping"); }
        public                   void     Twist() { _animator.SetTrigger("Twist"); }
    }
}