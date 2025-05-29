using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Mist.Backend.Data;
using Mist.Backend.Models;
using Mist.Backend.Repositories.Implementations;
using Mist.Backend.Repositories.Interfaces;
using Mist.Backend.Services.Implementations;
using Mist.Backend.Services.Interfaces;
using System.Reflection;
using System.Text;


namespace Mist.StartupConfig
{
	public static class DependencyInjectionExtension
	{
		public static void AddConfiguration(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
		}

		public static void AddDbConnection(this WebApplicationBuilder builder)
		{
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

			builder.Services.AddDbContext<MistDbContext>(options =>
				options.UseNpgsql(connectionString));
		}

		/// <summary>
		/// Adds controllers, endpointApiExplorer, SwaggerGen
		/// </summary>
		/// <param name="builder"></param>
		public static void AddStandardServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();

			builder.AddSwaggerServices();
		}

		private static void AddSwaggerServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddSwaggerGen(c =>
			{
				// Load in xml file containing documentation and display it in swagger
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		/// <summary>
		/// Adds DI for services and repositories
		/// </summary>
		/// <param name="builder"></param>
		public static void AddCustomServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddScoped<IAuthService, AuthService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ITokenService, TokenService>();

			builder.Services.AddScoped<IAuthRepository, AuthRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
		}

		public static void AddAuthentication(this WebApplicationBuilder builder)
		{
			var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
			var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

			builder.Services.AddAuthentication(options =>
			{
				// Use JWT Bearer for [Authorize]
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

				// Use JWT Bearer to challenge unauthorize users when they want to access a resource
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					// Specify what needs to be verified for the token to be valid
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					// Specify what is considered "Valid" in a token
					ValidIssuer = jwtSettings.Issuer,
					ValidAudience = jwtSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(key)
				};
			});
		}


	}
}
