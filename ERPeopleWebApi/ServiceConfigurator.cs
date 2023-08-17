
using ERPeople.BLL.Services;
using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.DAL.Repositories;
using ERPeople.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace ERPeopleWebApi
{
    public static class ServiceConfigurator
    {

        public static void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                // loggingBuilder.ClearProviders();
                // loggingBuilder.AddConsole(); // Add the console logger
                //loggingBuilder.AddDebug();   // Add the debug logger

                // Add other log providers if needed
                // Install Nuget pkg Seq.Extension.Logging to use this provider
                loggingBuilder.AddSeq(); 
            });
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ERPeopleDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            // Inject Repo
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Inject Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();

            // Configure the Referrer Policy in your .NET 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
            });

            // Auto Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Inject Global Exception Handling
            services.AddTransient<ExceptionHandlingMiddleware>();
            

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }

    }
}
