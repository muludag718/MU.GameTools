using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using MU.GameTools.IO;
using MU.GameTools.Common;

namespace MU.GameTools.Prototype.FileFormats.Pure3D
{
	[TypeConverter(typeof(BaseNodeConverter))]
	public abstract class BaseNode : ISerializable, ICloneable
	{
		public enum RunToolType
		{
			None,
			TodEditor
		}

		public uint ID = uint.MaxValue;

		public BaseNode ParentNode;

		public List<BaseNode> Children = new List<BaseNode>();

		[DisplayName("Type ID")]
		[Category("Pure3D")]
		[TypeConverter(typeof(TypeIdConverter))]
		public virtual uint TypeId
		{
			get
			{
				object[] customAttributes = GetType().GetCustomAttributes(typeof(KnownTypeAttribute), inherit: false);
				if (customAttributes.Length == 1)
				{
					return ((KnownTypeAttribute)customAttributes[0]).Id;
				}
				return ID;
			}
		}

		[Category("Pure3D")]
		[Display(Order = 0)]
		[ReadOnly(true)]
		public uint StartPosition { get; set; }

		[Category("Pure3D")]
		[Display(Order = 0)]
		[ReadOnly(true)]
		public uint HeaderSize { get; set; }

		[Category("Pure3D")]
		[Display(Order = 0)]
		[ReadOnly(true)]
		public uint TotalSize { get; set; }

		[Browsable(false)]
		public PrototypeGame Game { get; set; }

		[Browsable(false)]
		public int ChildCount
		{
			get
			{
				if (Children == null)
				{
					return 0;
				}
				return Children.Count;
			}
		}

		[Browsable(false)]
		public virtual bool Exportable => false;

		[Browsable(false)]
		public virtual string ExportExtension => "";

		[Browsable(false)]
		public virtual bool Importable => false;

		[Browsable(false)]
		public virtual bool Runnable => false;

		[Browsable(false)]
		public virtual RunToolType RunTool => RunToolType.None;

		public override string ToString()
		{
			return GetType().Name;
		}

		public abstract void Serialize(Stream output, Endian endian);

		public abstract void Deserialize(Stream input, Endian endian);

		public virtual void Export(Stream output)
		{
			throw new InvalidOperationException();
		}

		public virtual void Import(Stream input)
		{
			throw new InvalidOperationException();
		}

		public virtual BaseNode RunNode()
		{
			return this;
		}

		public virtual object Preview()
		{
			return null;
		}

		public T GetParentNode<T>() where T : BaseNode
		{
			BaseNode parentNode = ParentNode;
			if (parentNode is T)
			{
				return parentNode as T;
			}
			if (parentNode != null)
			{
				return parentNode.GetParentNode<T>();
			}
			return null;
		}

		public T GetChildNode<T>() where T : BaseNode
		{
			return (T)Children.SingleOrDefault((BaseNode candidate) => candidate is T);
		}

		public List<T> GetChildNodes<T>() where T : BaseNode
		{
			return new List<T>(Children.OfType<T>());
		}

		public List<T> GetChildNodesRecursive<T>() where T : BaseNode
		{
			List<T> childNodes = GetChildNodes<T>();
			foreach (BaseNode child in Children)
			{
				List<T> childNodesRecursive = child.GetChildNodesRecursive<T>();
				childNodes.AddRange(childNodesRecursive);
			}
			return childNodes;
		}

		public object Clone()
		{
			Pure3DFile pure3DFile = new Pure3DFile();
			pure3DFile.Endian = Endian.Little;
			pure3DFile.GamePicked = Game;
			pure3DFile.Nodes.Add(this);
			Stream stream = new MemoryStream();
			pure3DFile.Serialize(stream, Endian.Little);
			stream.Position = 0L;
			pure3DFile.Nodes.Clear();
			pure3DFile.Deserialize(stream, Endian.Little);
			return pure3DFile.Nodes[0];
		}
	}
}
