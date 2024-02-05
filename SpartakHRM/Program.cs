using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SpartakHRM.UserService.API.Controllers;
using SpartakHRM.UserService.API.Mapper;
using SpartakHRM.UserService.API.MiddleWaries;
using SpartakHRM.UserService.API.Validators.Draft;
using SpartakHRM.UserService.API.Validators.User;
using SpartakHRM.UserService.BLL.Abstractions.Services;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.BLL.Services;
using SpartakHRM.UserService.Controllers;
using SpartakHRM.UserService.DAL;
using SpartakHRM.UserService.DAL.Interface;
using SpartakHRM.UserService.DAL.Repositories;
using StackExchange.Redis;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<UserModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<EmployeePersonalInfoDraftModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<EmployeeBusinessInfoDraftModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<DraftModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateUserViewModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateUserViewModelValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<CreateDraftValidator>();

    })
.AddJsonOptions(op =>
 {
     op.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

 });
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Service API", Version = "v1" });
});

// Read the connection string from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConn"));
builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);

// Register DAL dependencies
builder.Services.AddDALDependencies(configuration/*, useInMemoryDatabase: true*/);
// Register services and repositories
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserDraftService, UserDraftService>();
builder.Services.AddScoped<IOfficeService, OfficeService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<IUserDraftRepository, UserDraftRepository>();

// Register UserController and DraftController
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<OfficeController>();
builder.Services.AddScoped<DraftController>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(Program), typeof(ViewModelMappingProfile));

//// Register Validators
//builder.Services.AddScoped<IValidator<User>, UserModelValidator>();
//builder.Services.AddScoped<IValidator<DraftViewModel>, DraftModelValidator>();
//builder.Services.AddScoped<IValidator<EmployeePersonalInfoDraft>, EmployeePersonalInfoDraftModelValidator>();
//builder.Services.AddScoped<IValidator<EmployeeBusinessInfoDraft>, EmployeeBusinessInfoDraftModelValidator>();

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// Apply pending migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!dbContext.Database.IsInMemory())
    {
        dbContext.Database.Migrate();
    }

}

app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Service API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
