
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
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IAttendanceRepository, AttendanceRepository>();
            services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Inject Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<ILeaveRequestService, LeaveRequestService>();

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
