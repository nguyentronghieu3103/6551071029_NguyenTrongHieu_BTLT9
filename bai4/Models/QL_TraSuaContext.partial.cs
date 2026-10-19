using Microsoft.EntityFrameworkCore;

namespace bai4.Models;

public partial class QL_TraSuaContext
{
    public QL_TraSuaContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }
    }
}
