
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectApplication.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<TEntity> GetAsync(object id);
        Task<TEntity> GetByMostRecentAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<IEnumerable<TEntity>> GetListAsync(bool includeAll = false);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<IEnumerable<TEntity>> GetReportListAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task BulkInsertAsync(List<TEntity> entity);
        void Remove(TEntity entity);
        Task<int> ExecSP(string query);
        Task<IEnumerable<TEntity>> GetSPResult(string query);
        Task<int> ExecuteWithStoreProcedureAsync(string query, params object[] parameters);
    }
}
