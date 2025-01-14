﻿
using InterviewProjectDomain;
using InterviewProjectDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectInfrastructure.Persistence
{
    public class InterviewProjectContext:DbContext
    {
        public DbSet<Book> Book { get; set; }
        public InterviewProjectContext(DbContextOptions<InterviewProjectContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetDefaultFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDefaultFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDefaultFields()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity)
                {
                    var entity = ((BaseEntity)entry.Entity);
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entity.IsDeleted = true;
                            break;
                        case EntityState.Added:
                            entity.CreateDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entity.CreateDate = DateTime.UtcNow;
                            break;
                    }
                }
            }
        }
    }
}
