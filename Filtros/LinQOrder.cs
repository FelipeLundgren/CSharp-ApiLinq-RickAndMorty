using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project.Filtros;

internal class LinQOrder
{
    public static void OrdenarAlfabeticamente(List<Caracter> personagens) 
    { 
        var resultado = personagens.OrderBy(p => p.name).ToList();
        if (resultado.Count == 0)
        {
            Console.WriteLine($"\nNenhum personagem encontrado na Lista.");
        }
        else
        {
            Console.WriteLine($"\n--- Personagem Ordenados por Ordem alfabetica ---");
            foreach (var caracter in resultado)
            {
                Console.WriteLine($"Nome: {caracter.name} - ID: {caracter.id} - Status: {caracter.status} -");
            }
        }
    }
}
