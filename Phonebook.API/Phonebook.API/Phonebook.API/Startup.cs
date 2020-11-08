using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phonebook.Components;
using Phonebook.Components.Interfaces;
using Phonebook.Data;
using Phonebook.Helpers;
using Phonebook.Helpers.Interfaces;
using Phonebook.Helpers.MappingProfiles;
using Phonebook.Middleware;
using Phonebook.Repositories;
using Phonebook.Repositories.Interfaces;
using Prometheus;

namespace Phonebook.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                             .AllowAnyMethod()
                                                              .AllowAnyHeader()));

            RegisterDatabase(services);
            RegisterServices(services);
            RegisterDependencies(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SeedDatabase(app);

            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMetricServer();

            app.UseSwaggerService();

            app.UseMiddleware<ErrorHandlingMiddleWare>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void SeedDatabase(IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                PhonebookContext context = serviceScope.ServiceProvider.GetService<PhonebookContext>();
                PhonebookContextSeed.SeedAsync(context).Wait();
            }
        }
        private void RegisterDatabase(IServiceCollection services)
        {
            services.AddDbContext<PhonebookContext>(c =>
            c.UseInMemoryDatabase("PhonebookConnection"));

            //services.AddDbContext<PhonebookContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("PhonebookDB")));
        }
        private void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntryProfile));
            services.AddSwagger();
        }
        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IPhonebookRepository, PhonebookRepository>();
            services.AddScoped<IEntryComponent, EntryComponent>();
            services.AddScoped<IPhonebookComponent, PhonebookComponent>();
            services.AddSingleton<IMappingHelper, MappingHelper>();
        }
    }
}
