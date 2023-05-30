using Sport.Business.Servises.Interfaces;
using Sport.Business.Servises;
using System.Runtime.CompilerServices;
using FluentValidation.AspNetCore;
using FluentValidation;
using System;
using Sport.DataTransfer.Requests;
using Sport.DataTransfer.Validators;

namespace Sport.API.Extentions
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            
            services.AddScoped<IIdentityManager, IdentityManager>();

        }
    }
}
