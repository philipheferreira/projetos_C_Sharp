var builder = WebApplication.CreateBuilder(args);

// Habilita o uso de Controllers no projeto
builder.Services.AddControllers();

// 1. ADICIONE ESTA LINHA PARA LIBERAR O CORS:
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // Porta padrão do Vue CLI versao 2
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 2. ADICIONE ESTA LINHA PARA USAR O CORS (ANTES DO MAPCONTROLLERS):
app.UseCors("AllowVueApp");

// Mapeia as rotas dos Controllers para a internet
app.MapControllers();

app.Run();