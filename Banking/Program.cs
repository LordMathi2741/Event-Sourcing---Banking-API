using Banking.Account.Application.CommandServices;
using Banking.Account.Application.QueryServices;
using Banking.Account.Domain.Repositories;
using Banking.Account.Domain.Services;
using Banking.Account.Infrastructure.Persistence.EFC.Repositories;
using Banking.Account.Interfaces.ACL;
using Banking.Account.Interfaces.ACL.Services;
using Banking.Shared.Domain.Repositories;
using Banking.Shared.Infrastructure.Persistence.EFC.Configuration;
using Banking.Shared.Infrastructure.Persistence.EFC.Repositories;
using Banking.Shared.Interfaces.ASP.Configuration;
using Banking.Transfering.Application.CommandServices;
using Banking.Transfering.Application.OutboundServices.ACL;
using Banking.Transfering.Application.OutboundServices.ACL.Services;
using Banking.Transfering.Application.QueryServices;
using Banking.Transfering.Domain.Repositories;
using Banking.Transfering.Domain.Services;
using Banking.Transfering.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Banking API",
                Version = "v1",
                Description = "Banking Platform API Documentation",
                TermsOfService = new Uri("https://github.com/LordMathi2741"),
                Contact = new OpenApiContact
                {
                    Name = "LordMathi2741",
                    Email = "https://github.com/LordMathi2741"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
    });

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountDetailRepository,AccountDetailRepository>();
builder.Services.AddScoped<IAccountDetailCommandService,AccountDetailCommandService>();
builder.Services.AddScoped<IAccountDetailQueryService,AccountDetailQueryService>();
builder.Services.AddScoped<IAccountContextFacade, AccountContextFacade>();

builder.Services.AddScoped<ITransactionRepository,TransactionRepository>();
builder.Services.AddScoped<ITransactionCommandService,TransactionCommandService>();
builder.Services.AddScoped<ITransactionQueryService,TransactionQueryService>();
builder.Services.AddScoped<IExternalAccountService, ExternalAccountService>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllPolicy");


app.UseHttpsRedirection();

app.MapControllers();

app.Run();