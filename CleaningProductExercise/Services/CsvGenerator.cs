using CleaningProductExercise.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace CleaningProductExercise.Services
{
    public interface ICsvGenerator
    {
        string TextToCsv(params string[] text);
        string CsvToJson(string fileName);
    }

    public class CsvGenerator : ICsvGenerator
    {
        public string TextToCsv(params string[] text)
        {
            return string.Join(",", text);
        }

        public string CsvToJson(string fileName)
        {
            var data = File.ReadAllLines(fileName);

            var products = data.Skip(1).Select(line =>
            {
                var tokens = line.Split(',');

                return new Product
                {
                    RegistrationId = tokens[0],
                    ActiveIngredients = tokens[1].Split(';').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).ToList(),
                    ProductName = tokens[2],
                    VirusesKilled = tokens[3].Split(';').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).ToList(),
                    ContactTime = tokens[4],
                };
            }).ToList();

            var json = JsonConvert.SerializeObject(products);

            return json;
        }
    }
}
