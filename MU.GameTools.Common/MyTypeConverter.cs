using MU.GameTools.IO;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace MU.GameTools.Common;


public class MyTypeConverter : TypeConverter
{
    private class Descriptor : SimplePropertyDescriptor
    {
        private readonly string _DisplayName;

        private readonly string _Name;

        private readonly bool _ReadOnly;

        public override string DisplayName => _DisplayName;

        public override bool IsReadOnly => _ReadOnly;

        public Descriptor(Type componentType, Type elementType, string name, bool readOnly = false)
            : base(componentType, name, elementType, null)
        {
            _Name = name;
            _DisplayName = name.SeparateCamelCase();
            _ReadOnly = readOnly;
        }

        public override object GetValue(object instance)
        {
            return instance.GetType().GetProperty(_Name).GetValue(instance, null);
        }

        public override void SetValue(object instance, object value)
        {
            instance.GetType().GetProperty(_Name).SetValue(instance, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
    }

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (!(destinationType == typeof(string)))
        {
            return base.CanConvertTo(context, destinationType);
        }
        return true;
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType != typeof(string))
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
        if (value == null)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
        return value.ToString();
    }

    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
        List<PropertyDescriptor> list = new List<PropertyDescriptor>();
        PropertyInfo[] properties = value.GetType().GetProperties();
        foreach (PropertyInfo propertyInfo in properties)
        {
            DescriptableAttribute descriptableAttribute = (DescriptableAttribute)propertyInfo.GetCustomAttribute(typeof(DescriptableAttribute));
            if (descriptableAttribute != null)
            {
                list.Add(new Descriptor(value.GetType(), propertyInfo.PropertyType, propertyInfo.Name, descriptableAttribute.readOnly));
            }
        }
        return new PropertyDescriptorCollection(list.ToArray());
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
        return true;
    }
}
