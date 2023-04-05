using FluentValidation;
using Sport.DataTransfer.Requests;
using Sport.DataTransfer.Validators;
using FluentValidation.AspNetCore;

namespace Sport.API.Extentions
{
    public static class ValidationConfiguration
    {
        public static void ConfigureValidation(this IServiceCollection services)
        {        
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<SignUpRequest>, SignUpRequestValidator>();
            services.AddScoped<IValidator<SignInRequest>, SignInRequestValidator>();
        }
    }
}
