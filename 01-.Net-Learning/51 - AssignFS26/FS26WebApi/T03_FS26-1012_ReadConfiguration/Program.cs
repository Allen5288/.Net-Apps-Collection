namespace T03_FS26_1012_ReadConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;

            #region Method 1: Key-based Access
            Console.WriteLine("=== Method 1: Key-based Access ===");
            Console.WriteLine($"key = {config["key"]}");
            Console.WriteLine($"MySettings:AppName = {config["MySettings:AppName"]}");
            Console.WriteLine($"MySettings:Version = {config["MySettings:Version"]}");
            #endregion

            #region Method 2: GetSection().Get<T>()
            var mySettingsObj = config.GetRequiredSection("MySettings").Get<MySettings>();

            Console.WriteLine("\n=== Method 2: GetRequiredSection().Get<T>() ===");
            Console.WriteLine($"AppName = {mySettingsObj!.AppName}");
            Console.WriteLine($"Version = {mySettingsObj!.Version}");
            #endregion

            #region Method 3: Bind()
            var mySettingsManual = new MySettings();
            config.GetRequiredSection("MySettings").Bind(mySettingsManual);

            Console.WriteLine("\n=== Method 3: Bind() ===");
            Console.WriteLine($"AppName = {mySettingsManual.AppName}");
            Console.WriteLine($"Version = {mySettingsManual.Version}");
            #endregion

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
