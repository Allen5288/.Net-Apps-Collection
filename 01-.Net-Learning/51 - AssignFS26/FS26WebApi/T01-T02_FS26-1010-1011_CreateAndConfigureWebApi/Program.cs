using FS26WebApi.Configs;
using FS26WebApi.Services;

namespace FS26WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IUserService, UserService>();

            var mySettings = builder.Configuration
                .GetSection("MySettings")
                .Get<MySettings>();

            // Console.WriteLine($"Appname is: {mySettings!.AppName}, Version is: {mySettings.Version}");

            builder.Services.AddSingleton(mySettings!);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseMiddleware<FS26WebApi.Middlewares.RequestLoggingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
