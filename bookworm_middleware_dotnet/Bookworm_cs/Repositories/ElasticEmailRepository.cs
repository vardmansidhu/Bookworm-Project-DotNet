using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net;

public class ElasticEmailRepository
{
    private readonly HttpClient _client;
    private readonly string _apiKey;


    public ElasticEmailRepository(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _client = clientFactory.CreateClient();
        _client.BaseAddress = new Uri("https://api.elasticemail.com/v2/email/send");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

        _apiKey = configuration.GetValue<string>("elasticemail:api-key");
    }

    public async Task SendEmail(string from, string to, string subject, string body)
    {
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("apikey", _apiKey),
            new KeyValuePair<string, string>("subject", subject),
            new KeyValuePair<string, string>("from", from),
            new KeyValuePair<string, string>("to", to),
            new KeyValuePair<string, string>("bodyHtml", body)
        });

        var response = await _client.PostAsync("", content);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Failed to send email");
        }
    }
}
