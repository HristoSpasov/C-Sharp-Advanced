namespace _02.Graphic_Editor.Core
{
    using _02.Graphic_Editor.Contracts;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}