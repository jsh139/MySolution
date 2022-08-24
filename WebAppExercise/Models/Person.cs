using WebAppExercise.Attributes;

namespace WebAppExercise.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [SensitiveData]
        public string SSN { get; set; }

        [SensitiveData]
        public int Age { get; set; }
    }
}
