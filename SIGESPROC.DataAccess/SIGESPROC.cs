using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SIGESPROC.DataAccess.Context;
using System;

namespace SIGESPROC.DataAccess
{
    public class SIGESPROC : SIGESPROCContext
    {
        public static string ConnectionString { get; set; }

        public SIGESPROC()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public static void BuildConnectionString(string connection)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder { ConnectionString = connection };
            ConnectionString = connectionStringBuilder.ConnectionString;
        }

    }
}
