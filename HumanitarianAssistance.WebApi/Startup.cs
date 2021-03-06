using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HumanitarianAssistance.Common.ApplicationSettings;
using HumanitarianAssistance.Common.Helpers;
using HumanitarianAssistance.DataAccess.Data;
using HumanitarianAssistance.DataAccess.DbEntities;
using HumanitarianAssistance.Service;
using HumanitarianAssistance.Service.Classes;
using HumanitarianAssistance.Service.Classes.AccountingNew;
using HumanitarianAssistance.Service.Classes.Marketing;
using HumanitarianAssistance.Service.Classes.ProjectManagement;
using HumanitarianAssistance.Service.interfaces;
using HumanitarianAssistance.Service.interfaces.AccountingNew;
using HumanitarianAssistance.Service.interfaces.Marketing;
using HumanitarianAssistance.Service.interfaces.ProjectManagement;
using HumanitarianAssistance.WebApi.Auth;
using HumanitarianAssistance.WebApi.ChaHub;
using HumanitarianAssistance.WebApi.Extensions;
using HumanitarianAssistance.WebApi.Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace HumanitarianAssistance.WebApi
{
    public class Startup
    {
        private string DefaultCorsPolicyName;
        private const string SecretKey = "iNivDmHLpUA223sqsfhqGbMRdRj1PVkH"; // todo: get this from somewhere secure
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        public static IHostingEnvironment _Env;
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                               .SetBasePath(env.ContentRootPath)
                               .AddJsonFile(StaticResource.appsettingJsonFile, optional: true, reloadOnChange: true)
                               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                               .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // get and set environment variable at run time
            string connectionString = Environment.GetEnvironmentVariable("LINUX_DBCONNECTION_STRING");
            string DefaultsPolicyName = Environment.GetEnvironmentVariable("DEFAULT_CORS_POLICY_NAME");
            string DefaultCorsPolic = Environment.GetEnvironmentVariable("DEFAULT_CORS_POLICY_URL");
            string DefaultCorsPolicyUrl = Configuration["DEFAULT_CORS_POLICY_URL"];
            string WebSiteUrl = Environment.GetEnvironmentVariable("WEB_SITE_URL");

            DefaultCorsPolicyName = Configuration["DEFAULT_CORS_POLICY_NAME"];

            Console.WriteLine("Connection string: {0}\n", connectionString);

            services.AddDbContextPool<ApplicationDbContext>(options => options.UseNpgsql(connectionString));



            // ===== Add Identity ========
            services.AddIdentity<AppUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;

            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddSingleton<IRole, RoleService>();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("AuthMessageSenderOptions"));
            services.Configure<WebSiteUrl>(Configuration.GetSection("WEB_SITE_URL"));
            services.Configure<SwaggerEndPoint>(Configuration.GetSection("SwaggerEndPoint"));
            services.AddSingleton<IJwtFactory, JwtFactory>();
            services.AddTransient<IPermissions, PermissionService>();
            services.AddTransient<IOfficeDetails, OfficeDetailsService>();
            services.AddTransient<IPermissionsInRoles, PermissionsInRolesService>();
            services.AddTransient<IUserDetails, UserDetailsService>();
            services.AddTransient<ICurrency, CurrencyService>();
            services.AddTransient<IJournalDetail, JournalDetailService>();
            services.AddTransient<IEmailSetting, EmailSettingService>();
            services.AddTransient<IChartAccoutDetail, ChartAccountDetailService>();
            services.AddTransient<IVoucherDetail, VoucherDetailService>();
            services.AddTransient<IExchangeRate, ExchangeRateService>();
            services.AddTransient<IHREmployee, HREmployeeService>();
            services.AddTransient<IDesignation, DesignationService>();
            services.AddTransient<IAccountBalance, AccountBalanceService>();
            services.AddTransient<IProfession, ProfessionService>();
            services.AddTransient<ICode, CodeService>();
            services.AddTransient<ITaskAndActivity, TaskAndActivityService>();
            services.AddTransient<IStore, StoreService>();
            services.AddTransient<INotificationManager, NotificationManagerService>();
            services.AddTransient<IEmployeeDetail, EmployeeDetailService>();
            services.AddTransient<IEmployeeHR, EmployeeHRService>();
            services.AddTransient<IAccountRecords, AccountReportsService>();
            services.AddTransient<IProject, ProjectService>();
            services.AddTransient<IMasterPageService, MasterPageService>();
            services.AddTransient<IJobDetailsService, JobDetailsService>();
            services.AddTransient<IContractDetailsService, ContractDetailService>();
            services.AddTransient<IChartOfAccountNewService, ChartOfAccountNewService>();
            services.AddTransient<IPolicyService, PolicyService>();
            services.AddTransient<IClientDetails, ClientDetailsService>();
            services.AddTransient<IVoucherNewService, VoucherNewService>();
            services.AddTransient<ISchedulerService, SchedulerService>();
            services.AddTransient<IAccountBalance, AccountBalanceService>();
            services.AddTransient<IProjectActivityService, ProjectActivityService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IProjectPeopleService, ProjectPeopleService>();
            services.AddTransient<IFileManagement, FileManagementService>();
            services.AddTransient<IHiringRequestService, HiringRequestService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // configure JWT
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,
                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("JwtIssuerOptions:Issuer").Value,
                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("JwtIssuerOptions:Audience").Value,
                // Validate the token expiry
                ValidateLifetime = true,
                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JwtIssuerOptions:Issuer"],
                        ValidAudience = Configuration["JwtIssuerOptions:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero


                    };
                });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Trust", policy => policy.RequireClaim("Roles", "Admin", "SuperAdmin", "Accounting Manager", "HR Manager", "Project Manager", "Administrator"));
                options.AddPolicy("DepartmentUser", policy => policy.RequireClaim("OfficeCode"));
                options.AddPolicy("HRManager", policy => policy.RequireClaim("Roles", "HR Manager"));
                options.AddPolicy("Accounting", policy => policy.RequireClaim("Roles", "Accounting Manager"));
                options.AddPolicy("DepartmentUser", policy => policy.RequireClaim("DepartmentId"));

            });


            // Auto Mapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton(config.CreateMapper());


            //For Cors Setting
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, p =>
                {
                    // todo: Get from configuration
                    p.WithOrigins(DefaultCorsPolicyUrl).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });

            services.AddMvc().AddJsonOptions(c =>
                        {
                            c.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                            c.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        });

            // services.AddMvc(c => { c.Filters.Add(typeof(CustomException)); })
            //         .AddJsonOptions(a => a.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);

            services.AddRouting();
            services.AddSignalR();


            // swagger configuration
            services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new Info { Title = "CHA Core API", Description = "Swagger API" });

                p.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                p.IncludeXmlComments(xmlPath); // also update csproj file for this
            });









            // ------------------------------------------------------------------------------------------------
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "NewUI/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, ILogger<DbInitializer> logger)
        {
            // update database
            UpdateDatabase(app, _userManager, _roleManager, logger).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(DefaultCorsPolicyName);
            app.UseAuthentication();

            // swagger config
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // signal-r config
            app.UseSignalR(routes =>
            {
                routes.MapHub<ProjectChatHub>("/chathub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "NewUI";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        //2011
        private static async Task UpdateDatabase(IApplicationBuilder app, UserManager<AppUser> um, RoleManager<IdentityRole> rm, ILogger<DbInitializer> logger)
        {
            using (var serviceScope = app.ApplicationServices
              .GetRequiredService<IServiceScopeFactory>()
              .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();

                    if (!context.Users.Any())
                    {
                        await DbInitializer.CreateDefaultUserAndRoleForApplication(um, rm, context, logger);
                    }

                    // check if Contract Content present or not
                    if (!context.ContractTypeContent.Any())
                    {
                        await DbInitializer.AddContractClauses(context);
                    }

                    // check if JobGrade present or not
                    if (!context.JobGrade.Any())
                    {
                        await DbInitializer.AddJobGrades(context);
                    }

                    // check if Categories present or not
                    if (!context.Categories.Any())
                    {
                        await DbInitializer.AddMarketingCategory(context);
                    }
                    if (!context.ActivityStatusDetail.Any())
                    {
                        await DbInitializer.AddActivityStatus(context);
                    }
                }
            }
        }

    }
}
