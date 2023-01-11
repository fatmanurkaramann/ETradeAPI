using ETradeAPI.Application.Features.Auths.Rules;
using ETradeAPI.Application.Features.Categories.Rules;
using ETradeAPI.Application.Features.Orders.Rules;
using ETradeAPI.Application.Features.Products.Rules;
using ETradeAPI.Application.Services.AuthService;
using ETradeAPI.Core.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application
{
    public static class ApplicationServiceRegistiration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IAuthService, AuthManager>();            
            #region BusinessRulesDependencies
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<OrderBusinessRules>();
            #endregion
            return services;
        }
    }
}
