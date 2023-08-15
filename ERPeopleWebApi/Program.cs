using ERPeopleWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ServiceConfigurator.ConfigureLogging(builder.Services);

ServiceConfigurator.ConfigureServices(builder.Services, builder.Configuration);

IdentityConfigurator.ConfigureIdentity(builder.Services);

IdentityConfigurator.ConfigureAuthentication(builder.Services, builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication(); //Note: Always put UseAuthentication before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();




