using Microsoft.EntityFrameworkCore;

namespace Bai3.Models;

public partial class QL_DaNgoaiContext
{
    public static string ConnectionString { get; set; } = "Server=.\\SQLEXPRESS;Database=QL_DaNgoai;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=5;";

    public QL_DaNgoaiContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
