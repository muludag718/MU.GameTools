namespace MU.GameTools.Prototype.FileFormats
{
	public static class Constants
	{
		public const int BYTES_PER_FACE = 6;

		public const int BYTES_PER_VERTEXPOSITION = 12;

		public const int SIZE_OF_BONE_MATRIX = 118;

		public const int BONE_MATRIX_WIDTH = 4;

		public const int BONE_MATRIX_HEIGHT = 4;

		public const int DESCRIPTION_SIZE = 17;

		public const uint P1_TYPE_UV = 3556617u;

		public const uint P1_TYPE_POSITION = 747804969u;

		public const uint P1_TYPE_NORMAL = 3255221479u;

		public const uint P1_TYPE_TANGENT = 2752995909u;

		public const uint P1_TYPE_WEIGHT = 1230441723u;

		public const uint P1_TYPE_GROUP = 1943391143u;

		public const uint P1_TYPE_UVPAD1 = 949550084u;

		public const string P2_TYPE_UV = "tex0";

		public const string P2_TYPE_POSITION = "position";

		public const string P2_TYPE_NORMAL = "normal";

		public const string P2_TYPE_WEIGHTS = "weights";

		public const string P2_TYPE_TANGENT = "tangent";

		public const string P2_TYPE_FACES = "indices";

		public const string P2_TYPE_INDICES = "indices";

		public const string P2_TYPE_COLOUR0 = "colour0";

		public const string P2_TYPE_PAD = "pad";

		public const string P2_TYPE_UV1 = "tex1";

		public const string P2_TYPE_COEFFS0 = "coeffs0";

		public const string P2_TYPE_COEFFS1 = "coeffs1";

		public const string P2_TYPE_COEFFS2 = "coeffs2";

		public const string P2_TYPE_COEFFS3 = "coeffs3";

		public const string P2_TYPE_DIFFCOEFFS0 = "diffcoeffs0";

		public const string P2_TYPE_DIFFCOEFFS1 = "diffcoeffs1";

		public const string P2_TYPE_DIFFCOEFFS2 = "diffcoeffs2";

		public const string P2_TYPE_DIFFCOEFFS3 = "diffcoeffs3";

		public const float COMPRESSION_FACTOR3 = 127f;

		public const float DECOMPRESSION_FACTOR3 = 1f / 127f;

		public const float COMPRESSION_FACTOR6 = 32767f;

		public const float DECOMPRESSION_FACTOR6 = 3.051851E-05f;

		public static readonly int[][] STATIC_INDEX = new int[3][]
		{
			new int[2] { 1, 2 },
			new int[2] { 0, 2 },
			new int[2] { 0, 1 }
		};

		public const string ANIM_SCALE = "SCL\0";

		public const string ANIM_TRANSLATION = "TRAN";

		public const string ANIM_ROTATION = "ROT\0";

		public const int P1TodConstant = 916723515;

		public const int P2TodConstant = 217161721;
	}
}
