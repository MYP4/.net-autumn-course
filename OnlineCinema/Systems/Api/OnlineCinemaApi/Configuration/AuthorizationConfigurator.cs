using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using OnlineCinema.Context;
using OnlineCinema.Context.Entities;

namespace OnlineCinema.Api.Configuration;

public static class AuthorizationConfigurator
{
    public static void ConfigureAuthServices(this IServiceCollection services/*, FitnessClubSettings settings*/)
    {
        IdentityModelEventSource.ShowPII = true;
        services.AddIdentity<UserEntity, RoleEntity>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<OnlineCinemaDbContext>()
            .AddSignInManager<SignInManager<UserEntity>>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddInMemoryApiScopes(new[] { new ApiScope("api") })
            .AddInMemoryClients(new[]
            {
                new Client()
                {
                    ClientName = "client_id",//settings.ClientId,
                    ClientId = "client_id",//settings.ClientId,
                    Enabled = true,
                    AllowOfflineAccess = true,
                    AllowedGrantTypes = new List<string>()
                    {
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new("client_secret".Sha256() /*settings.ClientSecret.Sha256()*/)
                    },
                    AllowedScopes = new List<string>() { "api" }
                }
            })
            .AddAspNetIdentity<UserEntity>();

        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }
        ).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = "http://localhost:5151";//settings.IdentityServerUri;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api";
        });

        services.AddAuthorization();
    }

    public static void ConfigureAuthApplication(this IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}