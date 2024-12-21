using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using PedeAI.Domain.Interfaces;
using PedeAI.Infrastructure.Persistence;
using PedeAI.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PedeAI.WebAPI
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<MongoClientProvider>();

            // Registra o IMongoClient usando o MongoClientProvider
            services.AddSingleton<IMongoClient>(c =>
            {
                var provider = c.GetRequiredService<MongoClientProvider>();
                return provider.GetClient();
            });
            
            services.AddScoped(c =>
                c.GetService<IMongoClient>()?.StartSession());

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "MongoDB POC",
                        Version = "v1"
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}