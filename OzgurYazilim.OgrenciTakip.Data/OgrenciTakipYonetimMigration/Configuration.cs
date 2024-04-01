using OzgurYazilim.OgrenciTakip.Data.Contexts;
using System.Data.Entity.Migrations;

namespace OzgurYazilim.OgrenciTakip.Data.OgrenciTakipYonetimMigration
{
    public class Configuration : DbMigrationsConfiguration<OgrenciTakipYonetimContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}