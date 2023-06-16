using Microsoft.EntityFrameworkCore;
using MVCB03_C92_WEBAPIEX.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<dbDoctorsModel>(op =>
//{
//    op.UseSqlServer(builder.Configuration.GetConnectionString());
//});
builder.Services.AddDbContextPool<dbDoctorsModel>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")  );
    op.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddCors(op =>
{
    op.AddPolicy("doctor", option =>
    {
        option.AllowAnyHeader();
        option.AllowAnyMethod();
        option.AllowAnyOrigin();
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
app.UseCors("doctor");
app.MapControllers();

app.Run();
