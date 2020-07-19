using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialMedia.Core.src.CustomEntities;
using SocialMedia.Core.src.Interfaces.Repositories;
using SocialMedia.Core.src.Interfaces.Services;
using SocialMedia.Core.src.Interfaces.UniOfWork;
using SocialMedia.Core.src.Services;
using SocialMedia.Infrastructure.src.Data;
using SocialMedia.Infrastructure.src.Filters;
using SocialMedia.Infrastructure.src.Interfaces;
using SocialMedia.Infrastructure.src.Repositories;
using SocialMedia.Infrastructure.src.Services;
using System;

namespace SocialMedia.Api
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


            //Con esta linea de codigo va buscar los profile
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilters>();

            }).AddNewtonsoftJson(options =>
           {
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
               options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
           })
            .ConfigureApiBehaviorOptions(options =>
            {
                //options.SuppressModelStateInvalidFilter = true;
            });


            //Configurar una sección del archivo appSettings
            services.Configure<PaginationOptions>(Configuration.GetSection("Pagination"));


            services.AddDbContext<SocialMediaContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SocialMedia"))
            );

            services.AddTransient<IPostService, PostService>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IUriService>(provider =>
            {
                //Permite acceder al http del proyecto
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                //Saber si lo hacen por http o https
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });


            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
