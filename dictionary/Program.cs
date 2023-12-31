using dictionary.Configurations;
using dictionary.Contracts;
using dictionary.Data;
using dictionary.HeinzelnisseApi;
using dictionary.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DictionaryDbConnectionString");
builder.Services.AddDbContext<DictionaryDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.SwaggerDoc("heinzelnisse", new OpenApiInfo { Title = "Heinzelnisse API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

//the following code allow us to inject automapper anywhere and use it. It is now relative to out AutoMapperConfig.cs:
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddHttpClient<IHeinzelnisseApi,  HeinzelnisseApi>(HttpClient =>
{
    HttpClient.BaseAddress = new Uri("https://heinzelnisse.info/searchResults?searchItem=");
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IWordClassRepository, WordClassesRepository>();
builder.Services.AddScoped<IWordsRepository, WordsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
