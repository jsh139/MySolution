using CleaningProductExercise.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CleaningProductExercise.Services
{
    public interface IProductParser
    {
        void Parse(string fileName);
    }

    public class ProductParser : IProductParser
    {
        private const string GoodDataFile = "GoodData.csv";
        private const string BadDataFile = "BadData.json";

        private readonly IProductValidator _productValidator;
        private readonly ICsvGenerator _csvGenerator;

        public ProductParser(IProductValidator productValidator, ICsvGenerator csvGenerator)
        {
            _productValidator = productValidator;
            _csvGenerator = csvGenerator;
        }

        public void Parse(string fileName)
        {
            var csvData = new StringBuilder();
            var validProducts = new List<Product>();
            
            var productInputList = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(fileName));

            var invalidProducts = _productValidator.GetInvalidRegistrations(productInputList);
            var prodsWithValidRegistration = productInputList.Except(invalidProducts).ToList();

            foreach (var product in prodsWithValidRegistration)
            {
                if (_productValidator.IsValid(product))
                {
                    product.ContactTime = ((int)Math.Ceiling(double.Parse(product.ContactTime))).ToString();
                    validProducts.Add(product);
                }
                else
                {
                    invalidProducts.Add(product);
                }
            }

            csvData.AppendLine(_csvGenerator.TextToCsv("RegistrationId", "ActiveIngredients", "ProductName", "VirusesKilled", "ContactTime"));

            foreach (var product in validProducts
                .OrderBy(p => Convert.ToInt32(p.ContactTime))
                .ThenBy(p => p.ProductName))
            {
                csvData.AppendLine(_csvGenerator.TextToCsv(
                    product.RegistrationId,
                    string.Join(";", product.ActiveIngredients),
                    product.ProductName,
                    string.Join(";", product.VirusesKilled),
                    product.ContactTime));
            }

            File.WriteAllText($"{Environment.CurrentDirectory}\\{GoodDataFile}", csvData.ToString(), Encoding.UTF8);
            File.WriteAllText($"{Environment.CurrentDirectory}\\{BadDataFile}", JsonConvert.SerializeObject(invalidProducts), Encoding.UTF8);
        }
    }
}
