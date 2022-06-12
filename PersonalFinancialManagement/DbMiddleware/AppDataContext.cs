using Microsoft.EntityFrameworkCore;
using PersonalFinancialManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinancialManagement.DbMiddleware
{
    public class AppDataContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=82.146.56.114;user=external;password=superFinashka;database=Financial;", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
