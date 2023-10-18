using API_6._0_4.DBcontext;
using API_6._0_4.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Services_4.Mapper;
using Services_4.Services;
using System.Text;



using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Repositories_4.Repositories;

var builder = WebApplication.CreateBuilder(args);
//Add DB
builder.Services.AddDbContext<API_6._0_4.DBcontext.EF_DBcontext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

//void ConfigureServices
//(IServiceCollection services)
//{
//    services.AddControllersWithViews();
//    services.AddAutoMapper
//(typeof(MappingProfile).Assembly);
//}

//var config = new AutoMapper.MapperConfiguration(c=>
//{
//   c.AddProfile(new MappingProfile());
//});

//var mapper = config.CreateMapper();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add DI container
builder.Services.AddTransient<ServicesInterface,Services>();
builder.Services.AddTransient<RepositoryInterface<Province>, ProvinceRepository>();
builder.Services.AddTransient<RepositoryInterface<District>, DistrictRepository>();
builder.Services.AddTransient<RepositoryInterface<Ward>, WardRepository>();
builder.Services.AddTransient<RepositoryInterface<User>, UserRepository>();

//authen vs author

var key = builder.Configuration["Jwt:Key"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
    ).AddJwtBearer(options =>
{
    IConfigurationSection jwtSettings = builder.Configuration.GetSection("JwtSettings");
    string secretKey = jwtSettings["SecretKey"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],

        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],

        RequireExpirationTime = true,
        ValidateLifetime = true,

        //ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        RequireSignedTokens = true,
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    };
});





builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
});





builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Vô hi?u hóa ki?m tra ModelState
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//add authen 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Thêm xác thực JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/**/app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
