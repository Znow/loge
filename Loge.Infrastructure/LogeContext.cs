using Microsoft.EntityFrameworkCore;

namespace Loge.Infrastructure;

public class LogeContext : DbContext
{
    public DbSet<TransportOrder> TransportOrders { get; set; }
    
    public string DbPath { get; }
    
    // public LogeContext(DbContextOptions<LogeContext> contextOptions) : base(contextOptions)
    public LogeContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "loge.db");
    }
    
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}