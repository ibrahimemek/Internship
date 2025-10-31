using ArkBlog.Application.Abstracts;
using ArkBlog.Application.Abstracts.Services;
using ArkBlog.Application.Abstracts.Storages;
using ArkBlog.Application.Abstracts.Storages.AzureStorage;
using ArkBlog.Application.Abstracts.Storages.LocalStorage;
using ArkBlog.Infrustructure.Enums;
using ArkBlog.Infrustructure.Services;
using ArkBlog.Infrustructure.Services.Configuration;
using ArkBlog.Infrustructure.Services.Storages;
using ArkBlog.Infrustructure.Services.Storages.AzureStorage;
using ArkBlog.Infrustructure.Services.Storages.LocalStorage;
using Microsoft.Extensions.DependencyInjection;


namespace ArkBlog.Infrustructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IApplicationService, ApplicationService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();


        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
            services.AddScoped<ILocalStorage, LocalStorage>();

        }

        //Asagidaki metot bir overload olup, tercih edilmemektedir. Aksi durumda koda bagimli kaliriz. Sadece böyle olabilecegini de görmek amaciyla asagidaki kod olusturulmustur
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();

                    break;
            }
        }
    }
}
