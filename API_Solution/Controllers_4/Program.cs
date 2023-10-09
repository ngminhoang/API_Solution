using API_6._0_4.DBcontext;
using API_6._0_4.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services_4.Mapper;
using Services_4.Services;

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


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true; // Vô hi?u hóa ki?m tra ModelState
});

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
