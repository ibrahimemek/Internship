using Microsoft.Extensions.Configuration;

namespace ArkBlog.Persistence
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ArkBlog.Presentation"));
                configurationManager.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
