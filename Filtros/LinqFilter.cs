using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project.Filtros;

internal class LinqFilter
{
    public static void FiltrarPersonagensPorId(List<Caracter> personagens, int id)
    {
        var resultado = personagens.Where(p => p.id == id).ToList();
        if (resultado.Count == 0)
        {
            Console.WriteLine($"\nNenhum personagem encontrado com ID {id}.");
        }
        else
        {
            Console.WriteLine($"\n--- Personagem com ID {id} ---");
            foreach (var caracter in resultado)
            {
                Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} -");
            }
        }
    }

    public static void FiltrarPersonagensPorGenero(List<Caracter> personagens, string genero)
    {
        var resultado = personagens.Where(p => p.gender == genero).ToList();
        if (resultado.Count == 0)
        {
            Console.WriteLine($"\nNenhum personagem encontrado do Genero {genero}.");
        }
        else
        {
            Console.WriteLine($"\n--- Personagem do Genero {genero} ---");
            foreach (var caracter in resultado)
            {
                Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} -");
            }
        }
    }

    public static void FiltrarPersonagensPorStatus(List<Caracter> personagens, string status)
    {
        var resultado = personagens.Where(p => p.status == status).ToList();
        if (resultado.Count == 0)
        {
            Console.WriteLine($"\nNenhum personagem encontrado com Status {status}.");
        }
        else
        {
            Console.WriteLine($"\n--- Personagem com Status {status} ---");
            foreach (var caracter in resultado)
            {
                Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} -");
            }
        }
    }
}
    
