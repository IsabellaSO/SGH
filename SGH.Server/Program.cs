using Microsoft.EntityFrameworkCore;
using SGH.Server.Data;

var builder = WebApplication.CreateBuilder(args);


// Adicionar serviço de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Origem do Angular
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Adicione os controllers
builder.Services.AddControllers();

// Registre o DbContext AQUI (antes de builder.Build())
builder.Services.AddDbContext<HotelDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // <- Ativa a interface gráfica no navegador
}

app.UseHttpsRedirection();

// ⚠️ ESSENCIAL: Ativa o roteamento para as Controllers (QuartosController, etc.)
app.MapControllers();

app.Run();