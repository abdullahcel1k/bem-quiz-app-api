using Microsoft.EntityFrameworkCore;
using QuizApp.Core;
using QuizApp.Core.Services;
using QuizApp.Data;
using QuizApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QuizDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("QuizAppDatabase"),
    x => x.MigrationsAssembly("QuizApp.Data")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IUserService, UserService>();

// auto mapper eklendi
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

