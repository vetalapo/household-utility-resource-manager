using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using HurManager.Domain.Entities.Interfaces;

namespace HurManager.Core.Services.Session
{
    public interface ISession : IDisposable
    {
        IEnumerable<object> AddedEntities();

        IEnumerable<TEntity> AddedEntities<TEntity>()
            where TEntity : class;

        void AddEntity<TEntity>(TEntity entity)
            where TEntity : class;

        Task AddEntityAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class;

        IEnumerable<object> ChangedEntities();

        IEnumerable<TEntity> ChangedEntities<TEntity>()
            where TEntity : class;

        IEnumerable<object> DeletedEntities();

        IEnumerable<TEntity> DeletedEntity<TEntity>()
            where TEntity : class;

        void Flush();

        Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken));

        ISession IgnoreProperty<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        ISession IgnoreReference<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        bool IsNew<TEntity>(TEntity entity)
            where TEntity : class;

        bool IsPropertyModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        bool IsReferenceModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        TEntity Load<TEntity>(TEntity entity)
            where TEntity : class;

        Task<TEntity> LoadAsync<TEntity>(TEntity entity, CancellationToken token = default(CancellationToken))
            where TEntity : class;

        void RemoveEntity<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task RemoveEntityAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void UpdateEntity<TEntity>(TEntity entity)
            where TEntity : class;

        Task UpdateEntityAsync<TEntity>(TEntity entity)
            where TEntity : class;

        IQueryable<T> Query<T>(bool ignoreGlobalFilters = false)
            where T : class;
    }
}
