using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LendingLibrary.Data.Configurations;
using LendingLibrary.Entities;

namespace LendingLibrary.Data
{
    public class LendingLibraryContext : DbContext
    {
        public LendingLibraryContext() : base("LendingLibrary")
        {
            Database.SetInitializer<LendingLibraryContext>(null);
        }

        public IDbSet<Medium> MediumSet { get; set; }
        public IDbSet<Title> TitleSet { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new MediumConfiguration());
            modelBuilder.Configurations.Add(new TitleConfiguration());
        }
    }
}
