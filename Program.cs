using Microsoft.EntityFrameworkCore;
using sahibinden_project;
using sahibinden_project.Services;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Veritabanı yapılandırması
    builder.Services.AddDbContext<SahibindenDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Dependency Injection için servisleri ekleyin
    builder.Services.AddScoped<IRegisterService, RegisterService>();
    builder.Services.AddScoped<ILoginService, LoginService>();
    builder.Services.AddScoped<IListService, ListService>();
    builder.Services.AddScoped<ISaveListingService, SaveListingService>();
    builder.Services.AddScoped<IGetListingsService, GetListingsService>();
    builder.Services.AddScoped<IDeleteService, DeleteService>();
    builder.Services.AddScoped<IUpdateListingService, UpdateListingService>();
    builder.Services.AddScoped<IFavoriteListService, FavoriteListService>();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    // HTTP portunu belirtin
    app.Urls.Add("http://localhost:8000");
    
    app.Run();
}


