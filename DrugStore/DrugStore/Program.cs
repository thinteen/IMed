using DrugStore.Domain;
using DrugStore.Inftrastructure;
using DrugStore.Repositories.AdminAccountRepository;
using DrugStore.Repositories.BrandRepository;
using DrugStore.Repositories.MedicineRepository;
using DrugStore.Repositories.PharmacyRepository;
using DrugStore.Repositories.PhotoRepository;
using DrugStore.Services.AdminAccountService;
using DrugStore.Services.BrandService;
using DrugStore.Services.MedicineService;
using DrugStore.Services.PharmacyService;

var builder = WebApplication.CreateBuilder(args);

DrugStoreDbContext dbContext = new();

builder.Services.AddControllers();

builder.Services.AddSingleton(dbContext);

builder.Services.AddScoped<IBrandRepository, BrandRepository>();

builder.Services.AddScoped<IBrandService, BrandService>();

builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();

builder.Services.AddScoped<IMedicineService, MedicineService>();

builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();

builder.Services.AddScoped<IPharmacyService, PharmacyService>();

builder.Services.AddScoped<IAdminAccountRepository, AdminAccountRepository>();

builder.Services.AddScoped<IAdminAccountService, AdminAccountService>();

builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .WithOrigins("localhost:4200")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.MapControllers();
app.Run();