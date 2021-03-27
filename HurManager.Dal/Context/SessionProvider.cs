using System;
using System.Collections.Generic;

using HurManager.Core.Services.Session;

namespace HurManager.Dal.Context
{
    internal class SessionProvider : ISessionProvider
    {
        private readonly Func<HurManagerContext> _dbContextFactory;

        private bool _disposedValue = false;

        private ISession _currentSession;

        public SessionProvider(Func<HurManagerContext> dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }

        public ISession CurrentSession => this._currentSession ??= this.CreateSession();

        protected IList<ISession> Sessions { get; } = new List<ISession>();

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                {
                    foreach (var session in this.Sessions)
                    {
                        session.Dispose();
                    }
                }

                this._disposedValue = true;
            }
        }

        private ISession CreateSession()
        {
            var context = this._dbContextFactory();

            var result = new Session(context);

            context.RelatedSession = result;

            this.Sessions.Add(result);

            return result;
        }
    }
}
