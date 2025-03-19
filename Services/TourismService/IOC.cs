
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Business;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Context;
using MWS.Infrustructure.Repositories;
using MWS.Repository;
using TripBusiness.business;
using TripBusiness.Ibusiness;

namespace GWS.Service
{
    //inversion of controls ...
    public static class IOC
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            //Business dependencies ...
            services.AddScoped(typeof(ILoggerHandler<>), typeof(LoggerHandler<>));
            services.AddScoped<IClearString, ClearString>();
            services.AddScoped<ICommon, Common>();
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ITripCaching, TripCaching>();
            services.AddScoped<ICustomCaching, CustomCaching>();
            services.AddScoped<IUserRolePermission, UserRolePermission>();
            services.AddScoped<ISecurity, Security>();
            return services;
        }
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            //Infrastructure dependencies ...

            services.AddScoped(typeof(IProcedureCallingFactory), typeof(ProcedureCallingFactory));
            return services;
        }
        public static IServiceCollection AddGlobalDependencies(this IServiceCollection services)
        {

            //Global dependencies ...
            return services;
        }

        public static IServiceCollection AddDbContextsDependencies(this IServiceCollection services, IConfiguration config)
        {
            //AddDbContexts
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddDbContext<AGGRDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("AGGRDB"));
            });
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IProcedureCalling, ProcedureCalling>();

            return services;
        }
    }
}
