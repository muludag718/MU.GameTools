using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MU.GameTools.Prototype.Tod;


public class MetaAttributeConverter : TypeConverter
{
    public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
    {
        List<PropertyDescriptor> list = new List<PropertyDescriptor>();
        MetaAttribute metaAttribute = (MetaAttribute)value;
        foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(metaAttribute))
        {
            if (((BrowsableAttribute)property.Attributes[typeof(BrowsableAttribute)]).Browsable)
            {
                FieldInfo field = typeof(CategoryAttribute).Assembly.GetType("System.ComponentModel.MemberDescriptor").GetField("category", BindingFlags.Instance | BindingFlags.NonPublic);
                if (property.Category != "\u200bAttribute")
                {
                    field.SetValue(property, metaAttribute.TypeName);
                }
                list.Add(property);
            }
        }
        return new PropertyDescriptorCollection(list.ToArray());
    }

    public override bool GetPropertiesSupported(ITypeDescriptorContext context)
    {
        return true;
    }
}