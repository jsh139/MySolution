using CleaningProductExercise.Services;
using System;

namespace CleaningProductExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Normally would have an IOC container to Resolve these dependencies
            IProductParser productParser = new ProductParser(new ProductValidator(), new CsvGenerator());

            productParser.Parse($"{Environment.CurrentDirectory}\\CleaningProducts.json");
        }
    }
}
