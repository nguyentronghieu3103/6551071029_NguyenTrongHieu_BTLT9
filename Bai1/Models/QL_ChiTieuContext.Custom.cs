using Microsoft.EntityFrameworkCore;
using Bai1.Configuration;

namespace Bai1.Models;

public partial class QL_ChiTieuContext
{
    public QL_ChiTieuContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = ConfigurationHelper.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

public static class DbContextFactory
{
    public static QL_ChiTieuContext CreateContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<QL_ChiTieuContext>();
        optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString());
        return new QL_ChiTieuContext(optionsBuilder.Options);
    }
}
