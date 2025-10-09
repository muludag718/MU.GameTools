using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using MU.GameTools.IO;
using MU.GameTools.Prototype.Tod;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	public class TodTypeConverter : ExpandableObjectConverter
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
				MetaObject metaObject = ((MetaObjectData)instance).metaObject;
				return metaObject.GetType().GetProperty(_Name).GetValue(metaObject, null);
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

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			MetaObjectData metaObjectData = (MetaObjectData)value;
			List<PropertyDescriptor> list = new List<PropertyDescriptor>();
			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(metaObjectData.metaObject))
			{
				if (((BrowsableAttribute)property.Attributes[typeof(BrowsableAttribute)]).Browsable && (!(property.Name == "Attributes") || metaObjectData.metaObject.Attributes.Count > 0))
				{
					list.Add(new Descriptor(metaObjectData.metaObject.GetType(), property.PropertyType, property.Name));
				}
			}
			foreach (PropertyDescriptor property2 in base.GetProperties(context, value, attributes))
			{
				list.Add(property2);
			}
			foreach (PropertyDescriptor item in list)
			{
				FieldInfo field = typeof(CategoryAttribute).Assembly.GetType("System.ComponentModel.MemberDescriptor").GetField("category", BindingFlags.Instance | BindingFlags.NonPublic);
				if (item.Category == "Misc")
				{
					field.SetValue(item, "\u200b" + metaObjectData.metaObject.GetType().Name);
				}
			}
			return new PropertyDescriptorCollection(list.ToArray());
		}
	}
}
