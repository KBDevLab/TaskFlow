using TaskFlow.Client.Components;
using TaskFlow.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Configure HttpClient for services
var apiUrl = builder.Configuration["APIurl"] ?? "http://localhost:5032";
builder.Services.AddHttpClient("TaskFlowAPI", client => client.BaseAddress = new Uri(apiUrl));

// Register Services with Dependency Injection
builder.Services.AddScoped<IUsersService, UsersService>(provider => 
    new UsersService(provider.GetRequiredService<IHttpClientFactory>().CreateClient("TaskFlowAPI")));

builder.Services.AddScoped<ICommentsService, CommentsService>(provider => 
    new CommentsService(provider.GetRequiredService<IHttpClientFactory>().CreateClient("TaskFlowAPI")));

builder.Services.AddScoped<IProjectsService, ProjectsService>(provider => 
    new ProjectsService(provider.GetRequiredService<IHttpClientFactory>().CreateClient("TaskFlowAPI")));

builder.Services.AddScoped<ITasksService, TasksService>(provider => 
    new TasksService(provider.GetRequiredService<IHttpClientFactory>().CreateClient("TaskFlowAPI")));

// Add Blazor services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapBlazorHub(); // Required for Blazor Server SignalR
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();