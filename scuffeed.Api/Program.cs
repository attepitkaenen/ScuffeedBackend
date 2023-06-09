using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBKeyName") ?? throw new InvalidOperationException("Connection string 'PostContext' not found.")));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

    app.UseCors(cors =>
    {
        cors
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

