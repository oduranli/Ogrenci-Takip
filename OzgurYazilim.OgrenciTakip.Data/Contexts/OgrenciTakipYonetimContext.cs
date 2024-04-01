using OzgurYazilim.OgrenciTakip.Data.OgrenciTakipYonetimMigration;
using OzgurYazilim.OgrenciTakip.Model.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OzgurYazilim.OgrenciTakip.Data.Contexts
{
    public class OgrenciTakipYonetimContext : BaseDbContext<OgrenciTakipYonetimContext, Configuration>
    {
        public OgrenciTakipYonetimContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public OgrenciTakipYonetimContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Kurum> Kurum { get; set; }
    }
}