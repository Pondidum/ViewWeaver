using System;
using System.Runtime.Serialization;

namespace ViewWeaver.Helpers.GridPopulation
{
	[Serializable]
	public class MissingPopulatorException : Exception
	{
		public MissingPopulatorException()
		{
		}

		public MissingPopulatorException(string message)
			: base(message)
		{
		}

		public MissingPopulatorException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected MissingPopulatorException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
