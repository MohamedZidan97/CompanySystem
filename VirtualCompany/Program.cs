
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using VirtualCompany.Buisness_Layer.Interfaces;
using VirtualCompany.Buisness_Layer.Repositories;
using VirtualCompany.Models.Mail;

var builder = WebApplication.CreateBuilder(args);

// Core
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI To Identity
//Instance of Identity Usres and Roles
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options =>
    {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    }
    ).AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
   

// DbContext
var connectionString = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContextPool<ApplicationDbContext>(opt=>opt.UseSqlServer(connectionString));

// Send mail
var mailSettings = builder.Configuration.GetSection("MailSetting");
builder.Services.Configure<MailSetting>(mailSettings);
// add instance
builder.Services.AddScoped<EmployeeRep>();
builder.Services.AddScoped<IMailingRep,MailingRep>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(cors=> cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
