using System;
using System.Runtime.Serialization;

namespace HurManager.App.Common.Exceptions
{
    [Serializable]
    public abstract class UserFriendlyException : Exception
    {
        protected UserFriendlyException()
        {
        }

        protected UserFriendlyException(string message)
            : base(message)
        {
        }

        protected UserFriendlyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UserFriendlyException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
