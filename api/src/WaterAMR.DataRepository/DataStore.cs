using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.Utility;

namespace WaterAMR.DataRepository
{
    public class DataStore : DbContext
    {
        private string Provider = string.Empty;
        private string ConnectionString = "";
        public string ProviderName { get { return this.Provider; } }

        public DataStore(IConfiguration configHelper)
        {
            this.Provider = configHelper.GetSection("ConnectionStrings:ProviderName").Value.ToLower();
            this.ConnectionString = configHelper.GetSection("ConnectionStrings:ConnectionString").Value;
            //this.provider = ConfigurationManager.ConnectionStrings[ConnectionString].ProviderName.ToLower();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (this.Provider)
            {
                case "npgsql":
                    optionsBuilder.UseNpgsql(ConnectionString);
                    break;
                default:
                    optionsBuilder.UseSqlServer(ConnectionString);
                    break;
            }
            
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Name.ToLower();

                }

            }
        }
        //public IEnumerable<Organization> GetOrganization()
        //{
        //    var result = this.Set<Organization>();
        //    //var result1 = new List<DataModels.Organization>();
        //    //result1.Add(new DataModels.Organization() { organizationid = 1, code = "1", organizationname = "simple" });

        //    return result;
        //}
    }
}
