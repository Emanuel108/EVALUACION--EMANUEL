using Microsoft.EntityFrameworkCore;
using WebAppEvaluacionEmanuel.Data;

namespace WebAppEvaluacionEmanuel.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

            //Obtener cadena de conexión
            builder.Services.AddDbContext<WebAppEvaluacionEmanuelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppEvaluacionEmanuelDbContext")));

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");

            app.Run();
        }
    }
}