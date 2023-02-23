using Metsenat.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppDbContext();
builder.AddSerilogConfig();
builder.AddStripePaymentsInfrastructure();
builder.AddRequiredServicesAndRepos();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
