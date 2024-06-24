
using InterviewProjectDomain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProjectInfrastructure.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
               .Property(x => x.Publisher)
               .HasMaxLength(255);

            builder
               .Property(x => x.Title)
               .HasMaxLength(255);

            builder
               .Property(x => x.AuthorFirstName)
               .HasMaxLength(255);


            builder
                .Property(x => x.AuthorLastName)
                .HasMaxLength(255);

            builder
               .Property(x => x.Price)
               .HasColumnType("decimal(6, 2)");

            builder
               .Property(x => x.Price)
               .IsRequired();

            builder
               .Property(x => x.Price)
               .IsRequired(false);

            builder
              .Property(x => x.Year)
              .IsRequired(false);

            builder
             .Property(x => x.PlaceOfPublication)
             .HasMaxLength(255).IsRequired(false);
        }
    }
}
