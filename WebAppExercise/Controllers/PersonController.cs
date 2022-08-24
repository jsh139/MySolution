using Microsoft.AspNetCore.Mvc;
using WebAppExercise.Models;
using WebAppExercise.Security;
using WebAppExercise.Services;

namespace WebAppExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            var includePII = HttpContext.User.HasClaim(SecurityConstants.ClaimTypeIncludePII, string.Empty);

            return await _personService.GetPeople(includePII);
        }
    }
}