using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using HurManager.Core.Services.Session;
using HurManager.Domain.Entities.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace HurManager.Dal.Context
{
    internal class Session : ISession
    {
        private readonly HurManagerContext _context;

        private bool _disposedValue = false;

        public Session(HurManagerContext context)
        {
            this._context = context;
            this._context.RelatedSession = this;
        }

        public IDbConnection DbConnection => this._context.Database.GetDbConnection();

        public IEnumerable<object> AddedEntities()
        {
            return this._context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);
        }

        public IEnumerable<TEntity> AddedEntities<TEntity>()
            where TEntity : class
        {
            return this._context.ChangeTracker
                .Entries<TEntity>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);
        }

        public void AddEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            this._context.Set<TEntity>().Add(entity);
            Flush();
        }

        public Task AddEntityAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
        {
            this._context.Set<TEntity>().AddAsync(entity, cancellationToken);

            return FlushAsync();
        }

        public IEnumerable<object> ChangedEntities()
        {
            return this._context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);
        }

        public IEnumerable<TEntity> ChangedEntities<TEntity>()
            where TEntity : class
        {
            return this._context.ChangeTracker.Entries<TEntity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);
        }

        public IEnumerable<object> DeletedEntities()
        {
            return this._context.ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Deleted)
                .Select(x => x.Entity);
        }

        public IEnumerable<TEntity> DeletedEntity<TEntity>()
            where TEntity : class
        {
            return this._context.ChangeTracker.Entries<TEntity>()
                .Where(x => x.State == EntityState.Deleted)
                .Select(x => x.Entity);
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Flush()
        {
            this._context.SaveChanges();
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._context.SaveChangesAsync(cancellationToken);
        }

        public ISession IgnoreProperty<TEntity>(TEntity entity, string propertyName)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            if (entry.Metadata.FindProperty(propertyName) == null)
            {
                return this;
            }

            if (!entry.Property(propertyName).IsModified)
            {
                return this;
            }

            entry.Property(propertyName).IsModified = false;

            return this;
        }

        public ISession IgnoreReference<TEntity>(TEntity entity, string propertyName)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            if (entry.Metadata.FindProperty(propertyName) == null)
            {
                return this;
            }

            if (!entry.Reference(propertyName).IsModified)
            {
                return this;
            }

            entry.Reference(propertyName).IsModified = false;

            return this;
        }

        public bool IsNew<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);

            return entry.State == EntityState.Added;
        }

        public bool IsPropertyModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            if (entry.Metadata.FindProperty(propertyName) == null)
            {
                return false;
            }

            return entry.Property(propertyName).IsModified;
        }

        public bool IsReferenceModified<TEntity>(TEntity entity, string propertyName)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            if (entry.Metadata.FindProperty(propertyName) == null)
            {
                return false;
            }

            return entry.Reference(propertyName).IsModified;
        }

        public TEntity Load<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                navigation.Load();
            }

            foreach (var collection in entry.Collections)
            {
                collection.Load();
            }

            return entity;
        }

        public async Task<TEntity> LoadAsync<TEntity>(TEntity entity, CancellationToken token = default(CancellationToken))
            where TEntity : class
        {
            var entry = this._context.Entry(entity);
            foreach (var navigation in entry.Navigations)
            {
                await navigation.LoadAsync(token);
            }

            foreach (var collection in entry.Collections)
            {
                await collection.LoadAsync(token);
            }

            return entity;
        }

        public IQueryable<T> Query<T>(bool ignoreGlobalFilters = false)
            where T : class
        {
            return ignoreGlobalFilters
                ? this._context.Set<T>().IgnoreQueryFilters()
                : this._context.Set<T>();
        }

        public void RemoveEntity<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this._context.Set<TEntity>().Remove(entity);

            Flush();
        }

        public async Task RemoveEntityAsync<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            this._context.Set<TEntity>().Remove(entity);

            await FlushAsync();
        }

        public void UpdateEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            this._context.Set<TEntity>().Update(entity);
        }

        public async Task UpdateEntityAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            this._context.Set<TEntity>().Update(entity);

            await FlushAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                this._disposedValue = true;
            }
        }
    }
}
