using ALJ.Data.Models;
using ALJ.Data.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MWS.Business.ALJ.BusinessALJ;
using MWS.Business.ALJ.IBusinessALJ;
using MWS.Business.Malath.lease.Business;
using MWS.Business.Malath.lease.IBusiness;
using MWS.Business.Shared.Business;
using MWS.Business.Shared.Business.Business;
using MWS.Business.Shared.IBusiness;
using MWS.Infrustructure.Context;
using MWS.Infrustructure.Repositories;
using MWS.Repository;

namespace MWS.ALJU.Service
{
    //inversion of controls ...
    public static class IOC
    {
        public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
        {
            //Business dependencies ...
            services.AddScoped<IQuotationBusiness, QuotationBusiness>();
            services.AddScoped<IQuotationALJBusiness, QuotationALJBusiness>();
            services.AddScoped<ICommon, Common>();
            services.AddScoped<IClearString, ClearString>();
            services.AddScoped(typeof(ILoggerHandler<>), typeof(LoggerHandler<>));
            services.AddScoped(typeof(IValueHelper), typeof(ValueHelper));
            services.AddScoped(typeof(IDateConverter), typeof(DateConverter));
            services.AddScoped(typeof(ICustomCaching), typeof(CustomCaching));
            services.AddScoped(typeof(ILeaseCaching), typeof(LeaseCaching));
            services.AddScoped<MWS.Business.Shared.Business.IDateConverter, DateConverter>();

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
            services.AddScoped<IValidator<AljuQuotationRequest>, AljRequestValidation>();
            services.AddScoped<IValidator<CustomizedParameter>, CustomizedParameterValidation>();
            services.AddScoped<IValidator<DriverDetails>, DriverDetailsValidation>();
            services.AddScoped<IValidator<NationalAddress>, NationalAddressValidation>();
            return services;
        }

        public static IServiceCollection AddDbContextsDependencies(this IServiceCollection services, IConfiguration config)
        {
            //AddDbContexts

            services.AddDbContext<AGGRDbContext>(options =>
            {
                options.UseOracle(config.GetConnectionString("AGGRDB"));
            });
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IProcedureCalling, ProcedureCalling>();

            return services;
        }
    }
}
