using UrlShorteningService.Business.Handlers;
using UrlShorteningService.Business.Services;
using UrlShorteningService.Core.Repositories;
using UrlShorteningService.Core.Services;
using UrlShorteningService.Data;
using UrlShorteningService.Data.Repositories;

namespace UrlShorteningService
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddMemoryCache();
			//IOC Services
			builder.Services.AddScoped<IUrlService, UrlService>();

			//IOC Repositories
			builder.Services.AddScoped<IUrlDefinitionRepository, UrlDefinitionRepository>();

			//handlers
			builder.Services.AddScoped<TransactionLocker>();
			builder.Services.AddSingleton<DatabaseContext>();

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

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}