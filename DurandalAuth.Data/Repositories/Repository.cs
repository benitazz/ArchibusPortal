#region

using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using DurandalAuth.Domain.Repositories;

#endregion

namespace DurandalAuth.Data.Repositories
{
    /// <summary>
    ///     Generic Repository
    /// </summary>
    /// <typeparam name="TEntity">The generic entity type</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="context">Context</param>
        public Repository(DbContext context)
        {
            this.Context = context;
        }

        protected DbContext Context { get; private set; }

        /// <summary>
        ///     Get all Entities for the concrete type
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<TEntity> All()
        {
            return this.Context.Set<TEntity>();
        }

        /// <summary>
        ///     Find Entities based on the required predicate
        /// </summary>
        /// <param name="predicate">The predicate</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        ///     Find first or default Entity
        /// </summary>
        /// <param name="predicate">The search predicate</param>
        /// <returns>The Entity</returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        ///     Find first Entity matching predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>The Entity</returns>
        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).First();
        }

        /// <summary>
        ///     Get Entity by identity
        /// </summary>
        /// <param name="id">The identity</param>
        /// <returns>The Entity</returns>
        public virtual TEntity GetById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///     Add Entity to the working Context
        /// </summary>
        /// <param name="entity">The Entity</param>
        public virtual void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///     Remove Entity to the working Context
        /// </summary>
        /// <param name="entity">The Entity</param>
        public virtual void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        ///     Attach Entity to the working Context
        /// </summary>
        /// <param name="entity">The Entity</param>
        public virtual void Attach(TEntity entity)
        {
            this.Context.Set<TEntity>().Attach(entity);
        }
    }
}