using SoftUni.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace SoftUni.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SoftUniDbContext db;

        protected IDbSet<T> DbSet { get; set; }

        public Repository(SoftUniDbContext db)
        {
            this.db = db;
            this.DbSet = this.db.Set<T>();
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable<T>();
        }

        public T Attach(T entity)
        {
            return this.DbSet.Attach(entity);
        }

        public void Delete(object id)
        {
            var entity = this.DbSet.Find(id);

            this.DbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity);
            }
        }

        public void Detach(T entity)
        {
            var entry = this.db.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.DbSet.Where(predicate);
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.db.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
