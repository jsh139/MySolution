using CleaningProductExercise.Models;
using System.Collections.Generic;
using System.Linq;

namespace CleaningProductExercise.Services
{
    public interface IProductValidator
    {
        List<Product> GetInvalidRegistrations(List<Product> products);
        bool IsValid(Product product);
    }

    public class ProductValidator : IProductValidator
    {
        public List<Product> GetInvalidRegistrations(List<Product> products)
        {
            return products
                .GroupBy(p => p.RegistrationId)
                .Where(grp => grp.Count() > 1 || string.IsNullOrWhiteSpace(grp.Key))
                .SelectMany(grp => grp).ToList();
        }

        public bool IsValid(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.RegistrationId))
            {
                return false;
            }

            if (!double.TryParse(product.ContactTime, out _))
            {
                return false;
            }

            return true;
        }
    }
}
