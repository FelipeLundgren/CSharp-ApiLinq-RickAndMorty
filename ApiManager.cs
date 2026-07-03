using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Project;

internal class ApiManager
{
    public List<Caracter> PersonagensAtuais { get; private set; } = new List<Caracter>();

    
    public async Task BuscarPersonagens()
    {
        var personagens = await BuscarPersonagensFiltrados(null, null, null);

        Console.WriteLine("\n--- Resultados (Primeira Página) ---");
        foreach (var caracter in personagens)
        {
            Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} - Gênero: {caracter.gender}");
        }
        Console.WriteLine("-----------------------------------");
    }

   
    public async Task<List<Caracter>> BuscarPersonagensFiltrados(string? nome, string? status, string? genero)
    {
        using HttpClient client = new HttpClient();

        var query = new List<string>();
        if (!string.IsNullOrWhiteSpace(nome)) query.Add($"name={Uri.EscapeDataString(nome)}");
        if (!string.IsNullOrWhiteSpace(status)) query.Add($"status={Uri.EscapeDataString(status)}");
        if (!string.IsNullOrWhiteSpace(genero)) query.Add($"gender={Uri.EscapeDataString(genero)}");

        string url = "https://rickandmortyapi.com/api/character";
        if (query.Count > 0) url += "?" + string.Join("&", query);

        try
        {
            string resposta = await client.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<CaractersResponse>(resposta)!;
            PersonagensAtuais = data.results;
            return PersonagensAtuais;
        }
        catch (HttpRequestException)
        {
            
            PersonagensAtuais = new List<Caracter>();
            return PersonagensAtuais;
        }
    }
}