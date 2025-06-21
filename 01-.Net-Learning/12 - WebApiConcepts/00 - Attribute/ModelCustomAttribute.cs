
namespace _00___Attribute
{
    public class ModelCustomAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public bool IsRequired { get; set; }
        public ModelCustomAttribute(int maxLength, bool isRequired)
        {
            MaxLength = maxLength;
            IsRequired = isRequired;
        }
    }
}