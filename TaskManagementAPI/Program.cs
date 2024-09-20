using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TaskManagementAPI.Data;
using TaskManagementAPI.Filters;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        path: @"MyLog\Application.txt",
        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}][{Level}] {Message}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        flushToDiskInterval: TimeSpan.FromSeconds(10),
        fileSizeLimitBytes: 100 * 1024 * 1024, // 100MB
        rollOnFileSizeLimit: true,
        shared: true // Set true for multiple log write in same time.
                 )
    .WriteTo.Logger(errorLogger => errorLogger
        .MinimumLevel.Error()
        .WriteTo.File(
            path: @"MyLog\Application_ErrorOnly.txt",
            outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}][{Level}] {Message}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            flushToDiskInterval: TimeSpan.FromSeconds(10),
            fileSizeLimitBytes: 100 * 1024 * 1024, // 100MB
            rollOnFileSizeLimit: true,
            shared: true // Set true for multiple log write in same time.
                      )
        )
    .CreateLogger();

builder.Services.AddSerilog();

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<LoggingActionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddAuthentication();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
