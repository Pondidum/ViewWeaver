using System;
using System.Runtime.Serialization;

namespace ViewWeaver
{
    [Serializable]
    public class EventHandlerNotFoundException : Exception
    {
        private const string MessageFormat = "There is no event handler for the event '{0}' on presenter '{1}' expected '{2}'";

        public EventHandlerNotFoundException(string eventName, string handlerName, string typeName)
            : base(string.Format(MessageFormat, eventName, typeName, handlerName))
        {
            
        }

        public EventHandlerNotFoundException(SerializationInfo info, StreamingContext context)  
            : base(info, context)
        {
            
        }
    }
}