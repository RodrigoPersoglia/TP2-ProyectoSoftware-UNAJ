using AccessData;
using Application.Services;
using Application.Validations;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAlquileresRepository, AlquileresRepository>();
builder.Services.AddTransient<IValidationAlquiler, ValidationAlquiler>();
builder.Services.AddTransient<IAlquileresService, AlquileresService>();
builder.Services.AddTransient<IClientesRepository, ClientesRepository>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IValidationCliente, ValidationCliente>();

builder.Services.AddTransient<ILibrosRepository, LibrosRepository>();
builder.Services.AddTransient<ILibrosService, LibrosService>();
builder.Services.AddTransient<IValidationLibro, ValidationLibro>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                          policy.WithOrigins("http://localhost:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();

                      }
                      
                      );
});







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




