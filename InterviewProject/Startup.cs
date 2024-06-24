using InterviewProjectInfrastructure;
using InterviewProjectApplication;
using InterviewProjectApplication.Common.Mapping;

namespace InterviewProject
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MappingProfile));
            // services.AddJwtAuthentication(Configuration);
            services.AddApplication();
            services.AddPersistance(Configuration);
            //services.AddAmazonServices(Configuration);
            services.AddMemoryCache();
            services.AddCors();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );

            // app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger(
                 c => c.SerializeAsV2 = true
                );
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "InterviewProject");
                c.InjectJavascript("/swagger/ui/custom.js");
                c.InjectStylesheet("/swagger/ui/custom.css");
                c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "InterviewProject");
            }
                );
            app.UseStaticFiles();


            //app.UseDatabaseMigration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<BlackListTokenMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
