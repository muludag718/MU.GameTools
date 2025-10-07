namespace MU.GameTools.Common;

[AttributeUsage(AttributeTargets.Property)]
public class DescriptableAttribute : Attribute
{
    public readonly bool readOnly;

    public DescriptableAttribute()
    {
    }

    public DescriptableAttribute(bool readOnly)
    {
        this.readOnly = readOnly;
    }
}
