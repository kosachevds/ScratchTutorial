using System;

namespace ScratchTutorial
{
    class RegistrationException : Exception
    {
        public RegistrationException(string message) : base(message) { }
    }
}
