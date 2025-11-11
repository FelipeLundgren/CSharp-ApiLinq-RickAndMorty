using API_Project.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace API_Project;

internal class Menu
{
   
    public void ExibirMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("=== Rick and Morty API Navigator ===");
        Console.WriteLine("1. Listar todos os personagens");
        Console.WriteLine("2. Filtrar personagens");
        Console.WriteLine("3. Ordenar personagens personagens");
        Console.WriteLine("4. Criar documendo Json");
        Console.Write("\nEscolha uma opção (1-4): ");
    }


    public void MenuInicial()
    {
        ApiManager api = new();
        Menu menu = new Menu();

        while (true)
        {
            string opcao = Console.ReadLine();
            Console.WriteLine();
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    api.BuscarPersonagens().Wait();
                    Console.WriteLine("tecle para voltar ao menu");
                    Console.ReadKey();
                    menu.ExibirMenuPrincipal();
                    break;
                case "2":
                    Console.WriteLine("Deseja filtrar por id(1), genero(2) ou status(3)");
                    string op = Console.ReadLine();
                    Console.WriteLine();
                    switch (op)
                    {
                        case "1":
                            Console.WriteLine("Digite o ID do personagem");
                            int id = int.Parse(Console.ReadLine());
                            LinqFilter.FiltrarPersonagensPorId(api.PersonagensAtuais, id);
                            break;
                        case "2":
                            Console.WriteLine("Digite o genero do personagem - Male or Female");
                            string genero = Console.ReadLine();
                            LinqFilter.FiltrarPersonagensPorGenero(api.PersonagensAtuais, genero);
                            Console.ReadKey();
                            menu.ExibirMenuPrincipal();
                            break;
                        case "3":
                            Console.WriteLine("Digite o status do personagem - Dead, Alive, unknown ");
                            string status = Console.ReadLine();
                            LinqFilter.FiltrarPersonagensPorStatus(api.PersonagensAtuais, status);
                            Console.ReadKey();
                            menu.ExibirMenuPrincipal();
                            break;

                    }
                    break;
                case "3":
                    Console.WriteLine("Ordenando os personagens de forma alfabetica");
                    LinQOrder.OrdenarAlfabeticamente(api.PersonagensAtuais);
                    Console.ReadKey();
                    menu.ExibirMenuPrincipal();
                    ;
                    break;


                    //case "4":
                    //    // Criar documento JSON
                    //    _apiManager.CriarDocumentoJson();
                    //    break;
                    //case "S":
                    //case "sair":
                    //    continuarExecucao = false;
                    //    Console.WriteLine("Saindo do programa. Até mais!");
                    //    break;
                    //default:
                    //    Console.WriteLine("Opção inválida. Por favor, digite um número válido.");
                    //    break;
            }
        }

    }





}
