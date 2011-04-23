using System;

namespace ViewWeaver
{
    public class InvalidConfigurationException : Exception
    {
        public InvalidConfigurationException(string message) : base(message)
        { }
    }
}