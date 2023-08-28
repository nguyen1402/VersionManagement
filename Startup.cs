using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using IdentityServer.TokenValidation.Share;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using SC.Utilities;
using MicroRabbitMQ.Domain.Core.EventBus;
using MicroRabbitMQ.Infrastructure;
using SC.VersionManagement;
using SC.VersionManagement.Config;
using SC.VersionManagement.Helpers;
using System.Reflection;

namespace SC.VersionManagement
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private const string REDIS_CACHE_CONNECTION = "RedisConnect:ConnectionStrings";
        private const string URL_SSO = "SSO:Domain";
        private const string URL_CDN = "CDN:Domain";
        private const string SWAGGER_KEY_PREFIX_SUB = "Swagger:KeyPrefix_Sub";
        private const string WRITE_CONNECTION = @"SQLWriteConnection";
        private const string READ_CONNECTION = @"SQLReadConnection";
        private const string ISSUBSCRIBE = "AppSettings:IsSubscribe";
        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            Configuration = configuration;
            StaticConfig = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            //-------------Auto Mapper Configurations-------------
            services.AddSingleton(AutoMapperConfig.Register().CreateMapper());

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetValue<string>(REDIS_CACHE_CONNECTION);
            //});

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //MediatR
            services.AddOptions();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(Startup));

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            //-------------SSO-------------
            #region SSO
            var key = Encoding.ASCII.GetBytes(appSettings.Secret) ?? throw new ArgumentNullException($"Cannot find `Secret Setting`");
            services.AddAuthentication(SoftComTokenValidation.ConfigureAuthenticationOptions)
             .AddJwtBearer(options => SoftComTokenValidation.ConfigureJwtBearerOptions(options, key, Configuration.GetValue<string>(URL_SSO), false));
            #endregion

            //-------------Swagger-------------
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VersionManagement", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                            new List<string>()
                    }
                });
            });
            #endregion

            //-------------HttpClientFactory-------------
            #region HttpClientFactory

            #region CDN
            services.AddHttpClient("CDN", config =>
            {
                config.BaseAddress = new Uri(Configuration.GetValue<string>(URL_CDN));
                config.Timeout = new TimeSpan(0, 0, 30);
                config.DefaultRequestHeaders.Clear();
            });
            #endregion
            #endregion

            //-------------Business Services-------------
            #region Business Services
            services.AddSingleton<ICacheProvider>(x => new RedisCacheProvider(Configuration.GetValue<string>("RedisConnect:ConnectionStrings"),
                                                                        Configuration.GetValue<int>("RedisConnect:DefaultDatabase"),
                                                                        Configuration.GetValue<string>("RedisConnect:KeyPrefix")));

            //services.ConfigureOpenIdExtensions(Configuration.GetValue<string>(URL_SSO));
            //services.AddScoped<IDigipostServices, DigipostServices>();

            #endregion

            //-------------UnitOfWork-------------
            #region UnitOfWork
            services.AddScoped<IUnitOfWorkCommand>(x => new UnitOfWorkCommand(Configuration.GetConnectionString(WRITE_CONNECTION)));
            services.AddScoped<IUnitOfWorkQuery>(x => new UnitOfWorkQuery(Configuration.GetConnectionString(READ_CONNECTION)));
            #endregion

            //-------------Event-------------
            #region Event
            //services.AddTransient<AddBookingTagsEventHandle>();
            //services.AddTransient<IEventHandler<AddBookingTagsEvent>, AddBookingTagsEventHandle>();
            #endregion

            services.Configure<RequestLocalizationOptions>(
              opts =>
              {
                  var supportedCultures = new List<CultureInfo>
                  {
                                    new CultureInfo("vi-VN"),
                                    new CultureInfo("en-US"),
                                    new CultureInfo("ko-KR"),
                                    new CultureInfo("all"),
                  };
                  opts.DefaultRequestCulture = new RequestCulture("vi-VN");
                  // Formatting numbers, dates, etc.
                  opts.SupportedCultures = supportedCultures;
                  // UI strings that we have localized.
                  opts.SupportedUICultures = supportedCultures;
              });

            // lowercase routing 
            services.AddRouting(options => options.LowercaseUrls = true);

            DependencyContainer.RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentname}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetValue<string>(SWAGGER_KEY_PREFIX_SUB) + "/swagger/v1/swagger.json", "SC VERSIONMANAGEMENT API");
                c.RoutePrefix = "swagger";
            });

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Content")),
            //    RequestPath = "/Content"
            //});
            if (Convert.ToBoolean(Configuration.GetValue<string>(ISSUBSCRIBE)))
                ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            //eventBus.Subscribe<AddBookingTagsEvent, AddBookingTagsEventHandle>();
            //eventBus.Subscribe<RemoveBookingTagsEvent, RemoveBookingTagsEventHandle>();
            //eventBus.Subscribe<BeginStepEvent, BeginStepEventHandle>();

        }
    }
}
