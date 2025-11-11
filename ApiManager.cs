using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Project;

internal class ApiManager
{

    public List<Caracter> PersonagensAtuais { get; private set; } = new List<Caracter>();


    public async Task BuscarPersonagens()
    {
        // O HttpClient deve ser instanciado dentro do método, ou de forma mais eficiente, 
        // como um campo estático ou Singleton. Usaremos a forma simples por enquanto.
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // URL de requisição
                string url = "https://rickandmortyapi.com/api/character";


                string resposta = await client.GetStringAsync(url);

                // Desserializa a resposta. Certifique-se de que CaractersResponse está definido.
                var data = JsonSerializer.Deserialize<CaractersResponse>(resposta)!;


                PersonagensAtuais = data.results;

                Console.WriteLine("\n--- Resultados (Primeira Página) ---");

                // Exibe os resultados
                foreach (var caracter in PersonagensAtuais)
                {
                    Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} - Gênero: {caracter.gender}");
                }
                Console.WriteLine("-----------------------------------");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("\nErro na requisição. Verifique sua conexão ou a URL da API.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcorreu um erro ao processar os dados: {ex.Message}");
            }
        }
    }

    public void FiltrarPersonagensLocalmente()
    { 
    
    }

        // Adicione aqui outros métodos, como o de filtragem e ordenação, se quiser.
}

// Supondo que você tem as classes de modelo definidas em algum lugar
