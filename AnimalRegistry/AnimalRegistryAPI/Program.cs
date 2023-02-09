using AnimalRegistryAPI.DBUtils;
using AnimalRegistryAPI.Services;
using AnimalRegistryAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAnimalRepository, KindOfAnimalRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IAnimalSkillRepository, AnimalSkillRepository>();

DBMySQLUtils.host = builder.Configuration["MYSQL_DBHOST"] ?? builder.Configuration.GetConnectionString("MYSQL_DBHOST");
DBMySQLUtils.port = builder.Configuration["MYSQL_DBPORT"] ?? builder.Configuration.GetConnectionString("MYSQL_DBPORT");
DBMySQLUtils.password = builder.Configuration["MYSQL_PASSWORD"] ?? builder.Configuration.GetConnectionString("MYSQL_PASSWORD");
DBMySQLUtils.userid = builder.Configuration["MYSQL_USER"] ?? builder.Configuration.GetConnectionString("MYSQL_USER");
DBMySQLUtils.database = builder.Configuration["MYSQL_DATABASE"] ?? builder.Configuration.GetConnectionString("MYSQL_DATABASE");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => {
    config.EnableAnnotations();
});

var app = builder.Build();

// Prepare database
DBConfigure.PrepareDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
