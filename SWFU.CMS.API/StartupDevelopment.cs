using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SWFU.CMS.API.Extensions;
using SWFU.CMS.Core.interfaces;
using SWFU.CMS.Insfrastructure.Database;
using SWFU.CMS.Insfrastructure.Repositories;
using SWFU.CMS.Insfrastructure.Resources;

namespace SWFU.CMS.API
{
    public class StartupDevelopment
    {
        public static IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
//            services.AddDbContext<MyContext>(options => { options.UseSqlite("Data Source=cms.db"); });
            services.AddDbContext<MyContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlite("Data Source=cms.db");
            });
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMvc();
            services.AddAutoMapper();
            services.AddTransient<IValidator<PostResource>, PostResourceValidator>();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,ILoggerFactory loggerFactory)
        {
//            app.UseDeveloperExceptionPage();
            app.UseMyExceptionHandler(loggerFactory);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}