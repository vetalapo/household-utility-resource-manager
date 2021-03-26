using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using HurManager.Domain.Entities.Interfaces;

namespace HurManager.Core.Services.Session
{
    public interface ISession : IDisposable
    {
        Guid Id { get; }

        IEnumerable<object> AddedEntities();

        IEnumerable<TEntity> AddedEntities<TEntity>()
            where TEntity : class;

        void AddEntity<TEntity>(TEntity entity)
            where TEntity : class;

        Task AddEntityAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class;

        Task AddEntityWithoutFlushAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class;

        IEnumerable<object> ChangedEntities();

        IEnumerable<TEntity> ChangedEntities<TEntity>()
            where TEntity : class;

        IEnumerable<object> DeletedEntities();

        IEnumerable<TEntity> DeletedEntity<TEntity>()
            where TEntity : class;

        void Flush();

        Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken));

        ISession IgnoreProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class;

        ISession IgnoreProperty<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        ISession IgnoreReference<TEntity, TReference>(TEntity entity, Expression<Func<TEntity, TReference>> propertyExpression)
            where TEntity : class
            where TReference : class;

        ISession IgnoreReference<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        bool IsNew<TEntity>(TEntity entity)
            where TEntity : class;

        bool IsPropertyModified<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> propertyExpression)
            where TEntity : class;

        bool IsPropertyModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        bool IsReferenceModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class;

        bool IsReferenceModified<TEntity, TReference>(TEntity entity, Expression<Func<TEntity, TReference>> propertyExpression)
            where TEntity : class
            where TReference : class;

        TEntity Load<TEntity>(TEntity entity)
            where TEntity : class;

        Task<TEntity> LoadAsync<TEntity>(TEntity entity, CancellationToken token = default(CancellationToken))
            where TEntity : class;

        IQueryable<T> Query<T>(bool ignoreGlobalFilters = false)
            where T : class;

        IQueryable<T> Query<T>(string sql, bool ignoreGlobalFilters, params object[] parameters)
            where T : class;

        IQueryable<T> QueryView<T>()
            where T : class;

        IQueryable<T> QueryView<T>(string sql, params object[] parameters)
            where T : class;

        IEnumerable<object> RemovedEntities();

        IEnumerable<TEntity> RemovedEntities<TEntity>()
            where TEntity : class, IEntity;

        void RemoveEntity<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        Task RemoveEntityAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void UpdateEntity<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
