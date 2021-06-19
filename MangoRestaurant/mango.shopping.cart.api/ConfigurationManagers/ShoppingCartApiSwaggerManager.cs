using mango.infrastructure.boilerplate.managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mango.shopping.cart.api.ConfigurationManagers
{
    public class ShoppingCartApiSwaggerManager : DefaultSwaggerManager
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "mango.shopping.cart.api v1"));

            }
        }
        public override void ConfigureService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "mango.shopping.cart.api", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    Description = @$"Enter '{JwtBearerDefaults.AuthenticationScheme}' [space] and your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                                    {
                                        Reference= new OpenApiReference()
                                        {
                                            Type=ReferenceType.SecurityScheme,
                                            Id=JwtBearerDefaults.AuthenticationScheme
                                        },
                                        Scheme="oauth2",
                                        Name=JwtBearerDefaults.AuthenticationScheme,
                                        In=ParameterLocation.Header

                                    }
                        ,new List<String>()
                    }
                });
            });
        }
    }
}
