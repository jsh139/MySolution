using Newtonsoft.Json;
using WebAppExercise.Models;

namespace WebAppExercise.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople(bool includePII);
    }

    public class PersonService : IPersonService
    {
        public async Task<List<Person>> GetPeople(bool includePII)
        {
            var text = await File.ReadAllTextAsync($"{AppDomain.CurrentDomain.BaseDirectory}people.json");

            var people = JsonConvert.DeserializeObject<List<Person>>(text);

            if (!includePII)
            {
                people?.ForEach(p =>
                {
                    p.Age = -99;
                    p.SSN = "XXXXXX";
                });
            }

            return people ?? new List<Person>();
        }
    }
}
