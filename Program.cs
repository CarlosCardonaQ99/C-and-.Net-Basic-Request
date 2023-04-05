using System;
using System.Net; //Trabajar con peticiones http hacer peticiones a otro servidor y recibir formatos JSON
using Newtonsoft.Json; // después de haber usado el comando dotnet add package Newtonsoft.Json
using System.Threading.Tasks; //asíncrono

namespace MyApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string API_URL = "https://jsonplaceholder.typicode.com/posts?_limit=5"; //Dirección a la cual pedir datos
            var client = new HttpClient();
            var json = await client.GetStringAsync(API_URL);
            Console.WriteLine(json);

            dynamic posts = JsonConvert.DeserializeObject(json);
            foreach (var post in posts) {
                Console.WriteLine(post.id + ": " + post.title);
            }
        }
    }
}

