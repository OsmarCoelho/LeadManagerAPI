using System.Reflection.Metadata;
using LeadManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PostgreSQL.Data
{
    public class ApiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("LeadManagerDataBse"));
        }

        public DbSet<Lead> Leads { get; set; }

    }
}