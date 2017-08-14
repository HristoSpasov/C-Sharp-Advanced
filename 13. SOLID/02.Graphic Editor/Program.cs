namespace _02.Graphic_Editor
{
    using System;
    using System.Collections.Generic;
    using _02.Graphic_Editor.Contracts;
    using _02.Graphic_Editor.Entities;

    public class Program
    {
        public static void Main()
        {
            List<IShape> shapes = new List<IShape>()
            {
                new Circle(),
                new Rectangle(),
                new Square()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
    }
}