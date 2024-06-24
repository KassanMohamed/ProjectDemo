using InterviewProjectApplication.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectInfrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false)
        {
            if (includeAll)
                return await Context.Set<TEntity>().IncludeAll().FirstOrDefaultAsync(predicate);

            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> GetByMostRecentAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false)
        {
            if (includeAll)
                return await Context.Set<TEntity>().IncludeAll().Where(predicate).OrderByDescending(x => "Id").FirstOrDefaultAsync();

            return await Context.Set<TEntity>().Where(predicate).OrderByDescending(x => "Id").FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(bool includeAll = false)
        {
            if (includeAll)
                return await Context.Set<TEntity>().IncludeAll().ToListAsync();

            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false)
        {
            if (includeAll)
                return await Context.Set<TEntity>().IncludeAll().Where(predicate).ToListAsync();
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetReportListAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false)
        {
            if (includeAll)
                return await Context.Set<TEntity>().IncludeAll().Where(predicate).OrderByDescending(x => "repoton").ToListAsync();
            return await Context.Set<TEntity>().Where(predicate).OrderByDescending(x => "repoton").ToListAsync();
        }


        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).CountAsync();
        }

    
        public async Task<IEnumerable<TEntity>> GetSPResult(string query)
        {
            var result = await Context.Set<TEntity>().FromSqlRaw(query).ToListAsync();
            return result;
        }

        public async Task<int> ExecSP(string query)
        {
            var result = Context.Database.ExecuteSqlRaw(query);
            Context.SaveChanges();
            if (result == 0)
                return 0;
            else
                return result;

        }

        public async Task<int> ExecuteWithStoreProcedureAsync(string query, params object[] parameters)
        {
            return await Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<decimal> ExecuteWithStoreProceduresAsync(string query)
        {
            return await Context.Database.ExecuteSqlRawAsync(query);
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task BulkInsertAsync(List<TEntity> entity)
        {
           await Context.Set<TEntity>().AddRangeAsync(entity);
           await Context.SaveChangesAsync();
        }
    }
}
