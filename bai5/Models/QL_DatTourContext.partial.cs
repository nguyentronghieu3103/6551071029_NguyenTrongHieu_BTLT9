using Microsoft.EntityFrameworkCore;

namespace bai5.Models;

public partial class QL_DatTourContext
{
    public QL_DatTourContext()
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
