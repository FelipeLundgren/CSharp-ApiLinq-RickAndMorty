using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Project;


public class Caracter
{
    public int id { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string gender { get; set; }
    public Origin origin { get; set; }
    // ... outras propriedades
}

public class Origin
{
    public string name;
    public string url;
}

public class CaractersResponse
{
    public object info { get; set; } // Pode ser uma classe se você precisar dos detalhes de paginação
    public List<Caracter> results { get; set; }
}






