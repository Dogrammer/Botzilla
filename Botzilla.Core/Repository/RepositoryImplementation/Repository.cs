using Botzilla.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botzilla.Core.Repository.RepositoryImplementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected Microsoft.EntityFrameworkCore.DbSet<TEntity> Set { get; }


        public Repository(ApplicationDbContext context)
        {
            _context = context;
            Set = context.Set<TEntity>();
        }
            public async Task<TEntity> Add(TEntity entity)
            {
            _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> Delete(long id)
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return entity;
                }

            _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return entity;
            }

            public async Task<TEntity> Get(long id)
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }

            public async Task<IEnumerable<TEntity>> GetAll()
            {
            return await _context.Set<TEntity>().ToListAsync();
            }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual IQueryable<TEntity> Queryable() => Set;


        //public async Task<TEntity> Update(TEntity entity)
        //    {
        //    _context.Set<TEntity>().Attach(entity);/*Entry(entity).. = EntityState.Modified;*/
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }

        public async Task<TEntity> Update(TEntity entity)
        {
            // _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await Save();

            return entity;


        }


    }
}
