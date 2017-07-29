using System;

namespace _10.Create_Custom_Class_Attribute.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MyCustomAttribute : Attribute
    {
        public MyCustomAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = reviewers;
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string[] Reviewers { get; set; }
    }
}