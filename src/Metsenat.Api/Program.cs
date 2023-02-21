using Metsenat.BLL.Repositories;
using Metsenat.BLL.Services;
using Metsenat.Common.Extenstions;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppDbContext();
builder.AddSerilogConfig();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISponsorRepository, SponsorRepository>();
builder.Services.AddScoped<ISponsorService, SponsorService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
