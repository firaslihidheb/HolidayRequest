using HolidaysManagement_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HolidaysManagement_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Function> Function { get; set; }
        public DbSet<HolidayRequest> Requests { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Function>()
                .HasKey(f => f.FunctionId);

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class ApplicationDbInitializer : IHostedService
    //{
    //    private readonly ApplicationDbContext _dbContext;

    //    public ApplicationDbInitializer(ApplicationDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }

    //    public async Task StartAsync(CancellationToken cancellationToken)
    //    {
    //        await _dbContext.Database.MigrateAsync();
    //        SeedData();
    //    }

    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        return Task.CompletedTask;
    //    }

    //    private void SeedData()
    //    {
    //        if (!_dbContext.Functions.Any())
    //        {
    //            _dbContext.Functions.AddRange(
    //                new Function { FunctionId = 1, FunctionName = "Function 1", Description = "hauatb" },
    //                new Function { FunctionId = 2, FunctionName = "Function 2", Description = "hauatb" }
    //            // Add more Function objects as needed
    //            );

    //            _dbContext.SaveChanges();
    //        }
    //    }
    //}

}
