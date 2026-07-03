using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Project;


public class Caracter
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string gender { get; set; } = string.Empty;
    public string image { get; set; } = string.Empty;
    public Origin? origin { get; set; }
}

public class Origin
{
    public string name { get; set; } = string.Empty;
    public string url { get; set; } = string.Empty;
}

public class CaractersResponse
{
    public object? info { get; set; } // Pode ser uma classe se você precisar dos detalhes de paginação
    public List<Caracter> results { get; set; } = new List<Caracter>();
}