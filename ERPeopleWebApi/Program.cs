using ERPeople.BLL.Services;
using ERPeople.DAL.Data;
using ERPeople.DAL.Interfaces;
using ERPeople.DAL.Repositories;
using ERPeople.DAL.UnitOfWork;
using ERPeopleWebApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole(); // Add the console logger
//builder.Logging.AddDebug(); // Add the debug logger

// Install Nuget pkg Seq.Extension.Logging to use this provider
builder.Logging.AddSeq();

builder.Services.AddDbContext<ERPeopleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Inject Repo
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddTransient<IShiftHoursRepository, ShiftHoursRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Inject Services
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();



// Inject Global Exception Handling
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8;
    // options.SignIn.RequireConfirmedAccount = true;

}).AddEntityFrameworkStores<ERPeopleDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{

    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

}
);

//tell Asp.Net engine how to authenticate and authorize this code
builder.Services.AddAuthentication(options =>
{

    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
        ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value))
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication(); //Note: Always put UseAuthentication before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();


