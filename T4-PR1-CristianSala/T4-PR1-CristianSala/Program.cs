using Microsoft.EntityFrameworkCore;
using T4_PR1_CristianSala.Data;
using T4_PR1_CristianSala.Service;
using static T4_PR1_CristianSala.Service.EcoEnergySeedingService;

namespace T4_PR1_CristianSala
{
    public class Program
    {
        public static async Task Main(string[] args) // Mark Main method as async and change return type to Task
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<EcoEnergyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<EcoEnergySeedingService>();
            builder.Services.AddScoped<EcoEnergyDbService>();

            var app = builder.Build();

            // Seed the database on startup
            using (var scope = app.Services.CreateScope())
            {
                var seedingService = scope.ServiceProvider.GetRequiredService<EcoEnergySeedingService>();
                await seedingService.SeedDatabaseAsync();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            await app.RunAsync(); // Use RunAsync instead of Run
        }
    }
}
