using Testapi.Repositories;
using Testapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IContentRepository, ContentRepository>();
builder.Services.AddSingleton<IContentService, ContentService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("allow",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
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

app.UseAuthorization();
app.MapControllers();
app.UseCors();
app.UseCors("allow");
app.Run();
