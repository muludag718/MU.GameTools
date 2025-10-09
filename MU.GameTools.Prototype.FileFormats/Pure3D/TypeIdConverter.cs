using System;
using System.ComponentModel;
using System.Globalization;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	internal class TypeIdConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
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
			if (destinationType == typeof(string) && value is uint)
			{
				return $"0x{value:X8}";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string text = value as string;
			if (text != null)
			{
				if (text.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
				{
					text = text.Substring(2);
				}
				return uint.Parse(text, NumberStyles.HexNumber, culture);
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
