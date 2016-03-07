using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LendingLibrary.Data.Infrastructure;
using LendingLibrary.Entities;

namespace LendingLibrary.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        private LendingLibraryContext _dataContext;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected LendingLibraryContext DbContext
        {
            get { return _dataContext ?? (_dataContext = this.DbFactory.Init()); }
        }

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DbContext.Set<T>();
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this.DbContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.DbContext.Set<T>().Where(predicate);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = this.DbContext.Entry<T>(entity);
            this.DbContext.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = this.DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = this.DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }
    }
}
