using System;
using System.ComponentModel;
using System.Globalization;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats
{
	public class VectorTypeConverter : TypeConverter
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
				if (instance is Vector2 vector)
				{
					string text = _Name;
					if (!(text == "X"))
					{
						if (text == "Y")
						{
							return vector.Y.ToString("0.000000", CultureInfo.InvariantCulture);
						}
						return null;
					}
					return vector.X.ToString("0.000000", CultureInfo.InvariantCulture);
				}
				if (instance is Vector3 vector2)
				{
					return _Name switch
					{
						"X" => vector2.X.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Y" => vector2.Y.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Z" => vector2.Z.ToString("0.000000", CultureInfo.InvariantCulture), 
						_ => null, 
					};
				}
				if (instance is Vector3Int vector3Int)
				{
					return _Name switch
					{
						"X" => vector3Int.X.ToString("0", CultureInfo.InvariantCulture), 
						"Y" => vector3Int.Y.ToString("0", CultureInfo.InvariantCulture), 
						"Z" => vector3Int.Z.ToString("0", CultureInfo.InvariantCulture), 
						_ => null, 
					};
				}
				if (instance is Vector4 vector3)
				{
					return _Name switch
					{
						"X" => vector3.X.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Y" => vector3.Y.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Z" => vector3.Z.ToString("0.000000", CultureInfo.InvariantCulture), 
						"W" => vector3.W.ToString("0.000000", CultureInfo.InvariantCulture), 
						_ => null, 
					};
				}
				if (instance is Vector4Int vector4Int)
				{
					return _Name switch
					{
						"X" => vector4Int.X.ToString("0", CultureInfo.InvariantCulture), 
						"Y" => vector4Int.Y.ToString("0", CultureInfo.InvariantCulture), 
						"Z" => vector4Int.Z.ToString("0", CultureInfo.InvariantCulture), 
						"W" => vector4Int.W.ToString("0", CultureInfo.InvariantCulture), 
						_ => null, 
					};
				}
				if (instance is Weight weight)
				{
					return _Name switch
					{
						"X" => weight.X.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Y" => weight.Y.ToString("0.000000", CultureInfo.InvariantCulture), 
						"Z" => weight.Z.ToString("0.000000", CultureInfo.InvariantCulture), 
						_ => null, 
					};
				}
				if (instance is UVCoordinate uVCoordinate)
				{
					string text = _Name;
					if (!(text == "U"))
					{
						if (text == "V")
						{
							return uVCoordinate.V.ToString("0.000000", CultureInfo.InvariantCulture);
						}
						return null;
					}
					return uVCoordinate.U.ToString("0.000000", CultureInfo.InvariantCulture);
				}
				if (instance is Face face)
				{
					return _Name switch
					{
						"Point 1" => face.Point1.ToString("0", CultureInfo.InvariantCulture), 
						"Point 2" => face.Point2.ToString("0", CultureInfo.InvariantCulture), 
						"Point 3" => face.Point3.ToString("0", CultureInfo.InvariantCulture), 
						_ => null, 
					};
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
			if (destinationType == typeof(string))
			{
				if (value is Vector2 vector)
				{
					return string.Format(CultureInfo.InvariantCulture, "Vector2 (X={0:0.000000}, Y={1:0.000000})", vector.X, vector.Y);
				}
				if (value is Vector3 vector2)
				{
					return string.Format(CultureInfo.InvariantCulture, "Vector3 (X={0:0.000000}, Y={1:0.000000}, Z={2:0.000000})", vector2.X, vector2.Y, vector2.Z);
				}
				if (value is Vector3Int vector3Int)
				{
					return string.Format(CultureInfo.InvariantCulture, "Vector3Int (X={0:0}, Y={1:0}, Z={2:0})", vector3Int.X, vector3Int.Y, vector3Int.Z);
				}
				if (value is Vector4 vector3)
				{
					return string.Format(CultureInfo.InvariantCulture, "Vector4 (X={0:0.000000}, Y={1:0.000000}, Z={2:0.000000}, W={3:0.000000})", vector3.X, vector3.Y, vector3.Z, vector3.W);
				}
				if (value is Vector4Int vector4Int)
				{
					return string.Format(CultureInfo.InvariantCulture, "Vector4Int (X={0:0.000000}, Y={1:0.000000}, Z={2:0.000000}, W={3:0.000000})", vector4Int.X, vector4Int.Y, vector4Int.Z, vector4Int.W);
				}
				if (value is Weight weight)
				{
					return string.Format(CultureInfo.InvariantCulture, "Weight (X={0:0.000000}, Y={1:0.000000}, Z={2:0.000000})", weight.X, weight.Y, weight.Z);
				}
				if (value is UVCoordinate uVCoordinate)
				{
					return string.Format(CultureInfo.InvariantCulture, "UV Coordinates (U={0:0.000000}, V={1:0.000000})", uVCoordinate.U, uVCoordinate.V);
				}
				if (value is Face)
				{
					return string.Format(CultureInfo.InvariantCulture, "Face");
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptor[] properties = null;
			if (value is Vector2)
			{
				PropertyDescriptor[] array = new Descriptor[2]
				{
					new Descriptor(typeof(Vector2), typeof(float), "X"),
					new Descriptor(typeof(Vector2), typeof(float), "Y")
				};
				properties = array;
			}
			else if (value is Vector3)
			{
				PropertyDescriptor[] array = new Descriptor[3]
				{
					new Descriptor(typeof(Vector3), typeof(float), "X"),
					new Descriptor(typeof(Vector3), typeof(float), "Y"),
					new Descriptor(typeof(Vector3), typeof(float), "Z")
				};
				properties = array;
			}
			else if (value is Vector3Int)
			{
				PropertyDescriptor[] array = new Descriptor[3]
				{
					new Descriptor(typeof(Vector3Int), typeof(uint), "X"),
					new Descriptor(typeof(Vector3Int), typeof(uint), "Y"),
					new Descriptor(typeof(Vector3Int), typeof(uint), "Z")
				};
				properties = array;
			}
			else if (value is Vector4)
			{
				PropertyDescriptor[] array = new Descriptor[4]
				{
					new Descriptor(typeof(Vector4), typeof(float), "X"),
					new Descriptor(typeof(Vector4), typeof(float), "Y"),
					new Descriptor(typeof(Vector4), typeof(float), "Z"),
					new Descriptor(typeof(Vector4), typeof(float), "W")
				};
				properties = array;
			}
			else if (value is Vector4Int)
			{
				PropertyDescriptor[] array = new Descriptor[4]
				{
					new Descriptor(typeof(Vector4Int), typeof(uint), "X"),
					new Descriptor(typeof(Vector4Int), typeof(uint), "Y"),
					new Descriptor(typeof(Vector4Int), typeof(uint), "Z"),
					new Descriptor(typeof(Vector4Int), typeof(uint), "W")
				};
				properties = array;
			}
			else if (value is Weight)
			{
				PropertyDescriptor[] array = new Descriptor[3]
				{
					new Descriptor(typeof(Weight), typeof(float), "X"),
					new Descriptor(typeof(Weight), typeof(float), "Y"),
					new Descriptor(typeof(Weight), typeof(float), "Z")
				};
				properties = array;
			}
			else if (value is UVCoordinate)
			{
				PropertyDescriptor[] array = new Descriptor[2]
				{
					new Descriptor(typeof(UVCoordinate), typeof(float), "U"),
					new Descriptor(typeof(UVCoordinate), typeof(float), "V")
				};
				properties = array;
			}
			else if (value is Face)
			{
				PropertyDescriptor[] array = new Descriptor[3]
				{
					new Descriptor(typeof(Face), typeof(uint), "Point 1"),
					new Descriptor(typeof(Face), typeof(string), "Point 2"),
					new Descriptor(typeof(Face), typeof(byte[]), "Point 3")
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
