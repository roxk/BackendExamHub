using Microsoft.EntityFrameworkCore;

namespace BackendExamHub;

public class AppDbContext : DbContext
{
    public required DbSet<MyOfficeAcpd> MyOfficeAcpds { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
