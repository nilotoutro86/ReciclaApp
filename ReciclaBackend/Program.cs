using Microsoft.EntityFrameworkCore;
using ReciclaBackend.Data; 



var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la DB 
// Configuración para usar SQLite 
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite("Data Source=ReciclaDB.db"));

// 2. Configurar CORS


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin() // Permitir cualquier origen
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


builder.Services.AddControllers();

builder.Services.AddControllers(); 


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated(); // ¡Esto creará la DB de SQLite!
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Usar CORS antes de la autorización
app.UseCors("CorsPolicy"); 


app.MapControllers();

app.Run();
