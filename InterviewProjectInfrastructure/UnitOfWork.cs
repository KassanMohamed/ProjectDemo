using InterviewProjectApplication.Abstractions.Repositories;
using InterviewProjectInfrastructure.Persistence;
using InterviewProjectInfrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectInfrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InterviewProjectContext _context;

        public UnitOfWork(InterviewProjectContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IRepository<T> GetReposiotory<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
