using System;

namespace HurManager.Core.Services.Session
{
    public interface ISessionProvider : IDisposable
    {
        ISession CurrentSession { get; }
    }
}
