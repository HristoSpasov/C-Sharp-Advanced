namespace _02.Graphic_Editor.Entities
{
    using _02.Graphic_Editor.Contracts;

    public class Rectangle : IShape
    {
        public string Draw()
        {
            return "I am rectangle!";
        }
    }
}