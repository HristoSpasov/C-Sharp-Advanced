namespace _02.Graphic_Editor.Entities
{
    using _02.Graphic_Editor.Contracts;

    public class Circle : IShape
    {
        public string Draw()
        {
            return "I am circle!";
        }
    }
}