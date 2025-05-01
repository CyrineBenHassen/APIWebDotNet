using TP6.Data;
using TP6.Repositories;
using Microsoft.EntityFrameworkCore;
using TP6.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Ajouter le DbContext avec la chaîne de connexion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injection du repository
builder.Services.AddScoped<ICategorieRepository, CategorieRepository>();


// Ajouter les contrôleurs
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
