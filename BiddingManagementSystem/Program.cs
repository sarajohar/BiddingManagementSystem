using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Application.Services;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using BiddingManagementSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// تسجيل المستودعات.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITenderRepository, TenderRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ITenderDocumentRepository, TenderDocumentRepository>();
builder.Services.AddScoped<IBidDocumentRepository, BidDocumentRepository>();

// تسجيل خدمات التطبيق.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IEvaluationService, EvaluationService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ITenderDocumentService, TenderDocumentService>();
builder.Services.AddScoped<IBidDocumentService, BidDocumentService>();

// تكوين المصادقة باستخدام JWT.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// تكوين مسار تدفق HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
