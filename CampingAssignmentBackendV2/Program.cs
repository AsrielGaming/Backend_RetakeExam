using CampingAssignmentBackendV2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();

//Adds support for API endpoint exploration (helps in generating OpenAPI/Swagger documentation).
builder.Services.AddEndpointsApiExplorer();

// Adds Swagger generator for API documentation.
builder.Services.AddSwaggerGen();

// Registers a singleton service, providing an instance of `AnonymousCampingDatabase` whenever `IAnonymousCampingDataContext` is requested.
builder.Services.AddSingleton(typeof(IAnonymousCampingDataContext), typeof(AnonymousCampingDatabase));

// Adds MVC services to the application (enables use of controllers and views).
builder.Services.AddMvc();

// Builds the WebApplication
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors error solution
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Enable HTTPS redirection (if needed)
//app.UseHttpsRedirection();

// Maps controller routes to the WebApplication
app.MapControllers();

// Runs the application
app.Run();
