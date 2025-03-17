using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Server.Data;
using TaskFlow.Server.Repositories.Implementations;
using TaskFlow.Server.Repositories.Interfaces;
using TaskFlow.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();

builder.Services.AddDbContext<TaskFlowDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskFlowDb")));

// builder.Services.AddControllers().AddJsonOptions(options =>
//     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Register repositories and services
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ITasksService, TasksService>();

builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();

builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ICommentsService, CommentsService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Optionally add versioning (commented out for now)
// builder.Services.AddApiVersioning(options =>
// {
//     options.ReportApiVersions = true;
//     options.AssumeDefaultVersionWhenUnspecified = true;
//     options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
// });

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");
// Uncomment if authentication/authorization is added in the future
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();