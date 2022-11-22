using DataLake.API.Profiles;
using DataLake.DataAccess;
using DataLake.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAutoMapper(options => options.AddProfile<AutoMapperProfiles>());
builder.Services.AddDependencies();
// Add services to the container.
builder.Services.AddDbContext<DataLakeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataLakeConnection")));
builder.Services.AddControllers();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}



app.UseStaticFiles();
app.UseRouting();

app.UseCors("corsapp");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
