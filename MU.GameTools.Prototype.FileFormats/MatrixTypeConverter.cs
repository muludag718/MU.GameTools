using System;
using System.ComponentModel;
using System.Globalization;

namespace MU.GameTools.Prototype.FileFormats
{
	public class MatrixTypeConverter : TypeConverter
	{
		private class Descriptor : SimplePropertyDescriptor
		{
			private readonly string _Name;

			public override bool IsReadOnly => true;

			public Descriptor(Type componentType, Type elementType, string name)
				: base(componentType, name, elementType, null)
			{
				_Name = name;
			}

			public override object GetValue(object instance)
			{
				if (instance is JointMatrix)
				{
					if (_Name == "Axis X")
					{
						return "";
					}
					return null;
				}
				return null;
			}

			public override void SetValue(object instance, object value)
			{
			}
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is JointMatrix jointMatrix)
			{
				return string.Format(CultureInfo.InvariantCulture, "Joint Matrix (Height = {0:0.000000}, Width = {1:0.000000})", jointMatrix.Height, jointMatrix.Width);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptor[] properties = null;
			if (value is JointMatrix)
			{
				PropertyDescriptor[] array = new Descriptor[4]
				{
					new Descriptor(typeof(JointMatrix), typeof(float[]), "Axis X"),
					new Descriptor(typeof(JointMatrix), typeof(float[]), "Axis Y"),
					new Descriptor(typeof(JointMatrix), typeof(float[]), "Axis Z"),
					new Descriptor(typeof(JointMatrix), typeof(float[]), "Position")
				};
				properties = array;
			}
			return new PropertyDescriptorCollection(properties);
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
