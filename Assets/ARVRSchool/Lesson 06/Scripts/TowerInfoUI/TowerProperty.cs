using Ru.Funreality.ARVRLessons.Lesson06.EnumerableData;

namespace Ru.Funreality.ARVRLessons.Lesson06
{
    public interface ITowerProperty : Data
    {
        string Name     { get; }
        object RawValue { get; }
    }

    public class TowerProperty<T> : ITowerProperty
    {
        public T      Value    { get; set; }
        public string Name     { get; set; }
        public object RawValue { get { return Value; } }
    }
}