using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Threading.Tasks;
using Bookworm_cs.Models;

[Route("[controller]")]
[ApiController]
public class ElasticEmailController : Controller
{
    private readonly ElasticEmailRepository _elasticEmailRepository;

    public ElasticEmailController(ElasticEmailRepository elasticEmailRepository)
    {
        _elasticEmailRepository = elasticEmailRepository;
    }

    [HttpPost("api/contact")]
    public async Task SendEmail([FromBody] ElasticEmail elasticEmail)
    {
        Console.WriteLine(elasticEmail.toString());
        string body = "Message from: " + elasticEmail.Name + "\n\n" + elasticEmail.Message;
        Console.WriteLine(body);
        await _elasticEmailRepository.SendEmail(elasticEmail.Email, "infinityrisky999@gmail.com", elasticEmail.Subject, body);
    }
}
