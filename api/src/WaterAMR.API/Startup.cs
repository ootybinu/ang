using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataAccess;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business;
using WaterAMR.BusinessModels.Security;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using WaterAMR.Utility;
using Microsoft.AspNetCore.Http;

namespace WaterAMR.API
{
    public class Startup
    {
        private IList<Token> tokens;
        private bool IsAutheticationRequired;
        private Int32 SessionTimeOut;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            tokens = new List<Token>();
            var auth= Configuration.GetSection("Authentication:Required").Value;
            IsAutheticationRequired = string.IsNullOrEmpty(auth) ? false : Convert.ToBoolean(auth);
            var timeout = Configuration.GetSection("Authentication:SessionTimeOut").Value;
            SessionTimeOut = string.IsNullOrEmpty(timeout) ? 20 : Convert.ToInt32(timeout);
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // change this policy for production 
            // as of now all are allowed for development -Binu
            services.AddCors(options => {
                options.AddPolicy("corsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            });

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IList<Token>>(tokens);
            services.AddSingleton<IUserInjection, UserInjection>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IUnitConsumptionRepository, UnitConsumptionRepository>();
            services.AddScoped<IUnitReportRepository, UnitReportRepository>();
            services.AddScoped<IGPRSdataRepository, GPRSdataRepository>();
            services.AddScoped<ISecurityRepository, SecurityRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IRevenueRepository , RevenueRepository>();
            services.AddScoped<IUnitSummaryRepository, UnitSummaryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOemRepository, OemRepository>();
            services.AddScoped<ITamperDetectionRepository, TamperDetectionRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IBillingRepository, BillingRepository>();
            services.AddScoped<ITariffRepository, TariffRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IOrganizationInfo, OrganizationInfo>();
            services.AddScoped<IUnitConsumptionService, UnitConsumptionService>();
            services.AddScoped<IUnitReportService, UnitReportService>();
            services.AddScoped<IGPRSdataService, GPRSdataService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<IUnitSummaryService, UnitSummaryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IOemService, OemService>();
            services.AddScoped<ITamperDetectionService, TamperDetectionService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IBillingService, BillingService>();
            services.AddScoped<ITariffService, TariffService>();
            services.AddScoped<IPaymentService, PaymentService>();
            // Add framework services.

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("corsPolicy");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (IsAutheticationRequired)
                app.UseMiddleware<AuthenticateMiddleware>(this.tokens,SessionTimeOut);

            app.UseExceptionHandler(
                builder=> {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            
                            var err = JsonConvert.SerializeObject(new error()
                            {
                                Stacktrace = ex.Error.StackTrace,
                                Message = ex.Error.Message
                            });
                            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
                        }
                    });
                } );
            app.UseMvc();
        }
    }
    public class error {
        public string Message { get; set; }
        public string Stacktrace { get; set; }
    }
}
