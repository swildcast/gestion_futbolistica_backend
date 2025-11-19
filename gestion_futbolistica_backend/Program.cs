using Microsoft.EntityFrameworkCore; // Importante para DbContext
using Microsoft.EntityFrameworkCore.SqlServer; // Import for SQL Server
using gestion_futbolistica_backend.Data; // Asegúrate del namespace de tu ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Añade servicios para explorar endpoints y generar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura CORS para permitir el frontend Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .WithMethods("GET", "POST", "PUT", "DELETE")
              .WithHeaders("Content-Type", "Authorization")
              .AllowCredentials();
    });
});

// Añade el DbContext configurado para SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
// Esto habilita Swagger solo en el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Interfaz de usuario para interactuar con la API
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization(); // Asegura que se verifiquen los permisos (aunque no los uses ahora)
app.MapControllers(); // Mapea las rutas de los controladores

app.Run(); // Inicia la aplicación
           // El segundo app.Run(); que tenías es redundante y debe eliminarse