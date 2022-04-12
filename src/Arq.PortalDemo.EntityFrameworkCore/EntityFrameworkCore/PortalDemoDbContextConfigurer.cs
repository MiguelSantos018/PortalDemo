using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Arq.PortalDemo.EntityFrameworkCore
{
    public static class PortalDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PortalDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PortalDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}