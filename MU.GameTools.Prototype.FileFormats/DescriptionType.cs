using System.ComponentModel;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	[TypeConverter(typeof(MyTypeConverter))]
	public class DescriptionType
	{
		protected object unknownValue;

		[Descriptable(true)]
		public DescriptionTypeEnum EnumValue { get; set; }

		public override string ToString()
		{
			return "Description Type (" + EnumValue.ToString() + ")";
		}

		public DescriptionType(uint value)
		{
			EnumValue = GetType(value);
		}

		public DescriptionType(string value)
		{
			EnumValue = GetType(value);
		}

		public DescriptionType(DescriptionTypeEnum value)
		{
			EnumValue = value;
		}

		public DescriptionTypeEnum GetType(uint value)
		{
			switch (value)
			{
			case 3556617u:
				return DescriptionTypeEnum.UV;
			case 747804969u:
				return DescriptionTypeEnum.Position;
			case 3255221479u:
				return DescriptionTypeEnum.Normal;
			case 2752995909u:
				return DescriptionTypeEnum.Tangent;
			case 1230441723u:
				return DescriptionTypeEnum.Weight;
			case 1943391143u:
				return DescriptionTypeEnum.Group;
			case 949550084u:
				return DescriptionTypeEnum.UVPadding1;
			default:
				unknownValue = value;
				return DescriptionTypeEnum.Unknown;
			}
		}

		public DescriptionTypeEnum GetType(string value)
		{
			value = value.TrimEnd(default(char));
			switch (value)
			{
			case "tex0":
				return DescriptionTypeEnum.UV;
			case "position":
				return DescriptionTypeEnum.Position;
			case "normal":
				return DescriptionTypeEnum.Normal;
			case "tangent":
				return DescriptionTypeEnum.Tangent;
			case "weights":
				return DescriptionTypeEnum.Weight;
			case "colour0":
				return DescriptionTypeEnum.Colour0;
			case "indices":
				return DescriptionTypeEnum.Group;
			case "pad":
				return DescriptionTypeEnum.Padding1;
			case "tex1":
				return DescriptionTypeEnum.UV1;
			default:
				unknownValue = value;
				return DescriptionTypeEnum.Unknown;
			}
		}

		public uint ToP1Type()
		{
			return EnumValue switch
			{
				DescriptionTypeEnum.UV => 3556617u, 
				DescriptionTypeEnum.Position => 747804969u, 
				DescriptionTypeEnum.Normal => 3255221479u, 
				DescriptionTypeEnum.Tangent => 2752995909u, 
				DescriptionTypeEnum.Weight => 1230441723u, 
				DescriptionTypeEnum.Group => 1943391143u, 
				DescriptionTypeEnum.UVPadding1 => 949550084u, 
				DescriptionTypeEnum.Unknown => (uint)unknownValue, 
				_ => 0u, 
			};
		}

		public string ToP2Type()
		{
			return EnumValue switch
			{
				DescriptionTypeEnum.UV => "tex0", 
				DescriptionTypeEnum.Position => "position", 
				DescriptionTypeEnum.Normal => "normal", 
				DescriptionTypeEnum.Weight => "weights", 
				DescriptionTypeEnum.Tangent => "tangent", 
				DescriptionTypeEnum.Colour0 => "colour0", 
				DescriptionTypeEnum.Padding1 => "pad", 
				DescriptionTypeEnum.Group => "indices", 
				DescriptionTypeEnum.UV1 => "tex1", 
				DescriptionTypeEnum.Unknown => (string)unknownValue, 
				_ => "", 
			};
		}
	}
}
