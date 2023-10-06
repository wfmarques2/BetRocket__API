using Application.Authorization;
using Application.CQRS.Player.Command.Response;
using Application.CQRS.Users.Handler;
using Application.CQRS.Users.Handlers;
using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra.Context;
using Infra.Entities;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BetRocket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<BetContext>(opt =>
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services
                .AddIdentity<EntityUser, IdentityRole>()
                .AddEntityFrameworkStores<BetContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserHandler).Assembly));
            
            builder.Services.AddMediatR(
                cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateAskForAdminHandler).Assembly));

            //builder.Services.AddMediatR(
            //    cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginUserHandler).Assembly));

            builder.Services.AddSingleton<IAuthorizationHandler, AgeAuthorization>();
            builder.Services.AddSingleton<IAuthorizationHandler, IsAdminAuthorization>();

            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<ISquadRepository, SquadRepository>();
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IMatchRepository, MatchRepository>();
            builder.Services.AddScoped<IBetRepository, BetRepository>();


            builder.Services.AddScoped<IUnitOfWork, UnitOfwork>();

            builder.Services.AddAuthorization(opt =>
            {
                opt.AddPolicy("MinAge", policy =>
                policy.AddRequirements(new MinAgeRequirement())
                );

                opt.AddPolicy("IsAdmin", policy =>
                policy.AddRequirements(new IsAdminRequirement())
                );
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BetApi", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes
                        (builder.Configuration["SymmetricSecurityKey"])),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddScoped<ITokenService<EntityUser>, TokenService>();
            builder.Services.AddScoped<AccessRequestRepository>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}