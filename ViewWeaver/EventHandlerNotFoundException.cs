using System;

namespace ViewWeaver
{
	[Serializable]
	public class MissingEventHandlerException : Exception
	{
		private const string MessageFormat = "There is no event handler for the event '{0}' on presenter '{1}' expected '{2}'";

		public MissingEventHandlerException(string eventName, string handlerName, string typeName)
			: base(string.Format(MessageFormat, eventName, typeName, handlerName))
		{

		}

	}

}
