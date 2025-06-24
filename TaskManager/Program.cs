using TaskManager.Database;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Task;
using TaskManager.Application.Service;
using Microsoft.Extensions.Options;
using TaskManager.Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


RepositoryOptions repositoryOptions = new();
builder.Configuration.GetSection("Repository").Bind(repositoryOptions);

builder.Services.AddSingleton<IOptions<RepositoryOptions>>(new OptionsWrapper<RepositoryOptions>(repositoryOptions));
builder.Services.AddDbContextFactory<ApplicationDBContext>(opt =>
{
    opt.UseSqlite(repositoryOptions.ConnectionString);
});

builder.Services.AddScoped<ITaskChange, TaskChangeService>();
builder.Services.AddScoped<IManager, ManagerService>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
