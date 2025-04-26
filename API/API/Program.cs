using API.Application.Interfaces;
using API.Application.Services;
using API.Data.ContextoDb;
using API.Data.Repositorio;
using API.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);


//Tomar cadena desde toda la aplicacion
var config = builder.Configuration;
var CadenaConexion = new ContextoDB(config.GetConnectionString("DbConnection"));
builder.Services.AddSingleton(CadenaConexion);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Servicios
//Application services
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<Ijemplo, jemplo>();

builder.Services.AddScoped<IProgramaService, ProgramaService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
//Data
//builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();



var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
       // builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}
else
{
    app.UseHttpsRedirection();
    app.UseAuthorization();
    //app.UseCors(prodCorsPolicy);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
