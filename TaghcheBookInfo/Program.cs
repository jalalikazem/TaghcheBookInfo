using TaghcheBookInfo.Application;
using TaghcheBookInfo.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddStackExchangeRedisCache(o => o.Configuration = builder.Configuration.GetSection("Redis").Value);
builder.Services.AddScoped<MemoryService>();
builder.Services.AddScoped<RedisService>();
builder.Services.AddScoped<TaghcheApiService>();
builder.Services.AddScoped<GetBookHandler>();

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
