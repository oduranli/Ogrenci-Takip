using OzgurYazilim.OgrenciTakip.Data.Contexts;
using System.Data.Entity.Migrations;

namespace OzgurYazilim.OgrenciTakip.Data.OgrenciTakipMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}