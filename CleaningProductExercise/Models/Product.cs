using System.Collections.Generic;

namespace CleaningProductExercise.Models
{
    public class Product
    {
        public string RegistrationId { get; set; }
        public List<string> ActiveIngredients { get; set; }
        public string ProductName { get; set; }
        public List<string> VirusesKilled { get; set; }
        public string ContactTime { get; set; }
    }
}
