using System;
using System.ComponentModel;
using System.Reflection;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	internal class BaseNodeConverter : ExpandableObjectConverter
	{
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = base.GetProperties(context, value, attributes);
			foreach (PropertyDescriptor item in properties)
			{
				FieldInfo field = typeof(CategoryAttribute).Assembly.GetType("System.ComponentModel.MemberDescriptor").GetField("category", BindingFlags.Instance | BindingFlags.NonPublic);
				if (item.Category == "Misc")
				{
					field.SetValue(item, "Node");
				}
			}
			return properties;
		}
	}
}
