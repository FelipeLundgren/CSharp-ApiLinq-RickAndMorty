using API_Project;

var builder = WebApplication.CreateBuilder(args);

// Libera o front-end (arquivo HTML aberto no navegador) a chamar essa API.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors();


app.UseDefaultFiles();
app.UseStaticFiles();

var api = new ApiManager();


app.MapGet("/api/personagens", async (string? name, string? status, string? gender) =>
{
    var personagens = await api.BuscarPersonagensFiltrados(name, status, gender);
    return Results.Ok(personagens);
});

app.Run();