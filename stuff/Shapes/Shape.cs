namespace stuff.Shapes
{
    public abstract class Shape
    {
        protected string ExceptionMessage = "The created shape cannot exist, please recheck the values";
        public abstract float Area();
        public abstract float Perimeter();
        protected abstract bool Exists();
    }
}