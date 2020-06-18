using System;
using Course.Data;
using Course.Data.Repository;

namespace CosmosDB.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new DocdbRepository<Product>();
            repo.Initialize();
            var prod = new Product
            {
                Id = "alfa",
                Name = "pc",
                Description = "laptop new",
                Price = 123.76
            };
            repo.CreateItemAsync(prod).Wait();
            Console.WriteLine("Hello World!");
        }
    }
}
