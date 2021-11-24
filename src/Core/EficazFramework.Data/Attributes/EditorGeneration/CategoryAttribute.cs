using System;

namespace EficazFramework.Attributes.UIEditor.EditorGeneration
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryAttribute : Attribute
    {
        public CategoryAttribute(string DescriptionOrResource)
        {
            Description = DescriptionOrResource;
        }

        public string Description { get; set; } = null;
    }
}