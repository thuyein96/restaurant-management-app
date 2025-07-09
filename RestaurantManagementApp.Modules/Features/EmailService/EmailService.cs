namespace RestaurantManagementApp.Modules.Helper.Email;

public class BrevoEmailService : IEmailService
{
    private readonly BrevoSettings _settings;
    private readonly HttpClient _httpClient;
    public BrevoEmailService(HttpClient httpClient, IOptions<BrevoSettings> options)
    {
        _settings = options.Value;
        _httpClient = httpClient;
    }

    public async Task<string> SendEmailAsync(string toEmail, string subject, string htmlBody)
    {
        var requestBody = new
        {
            sender = new { name = _settings.FromName, email = _settings.FromEmail },
            to = new[] { new { email = toEmail } },
            subject = subject,
            htmlContent = htmlBody
        };

        var stringcontent = JsonConvert.SerializeObject((await BuildEmail(toEmail, subject, htmlBody)));
        var content = new StringContent(stringcontent)
        {
            Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json")
            }
        };

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api.brevo.com/v3/smtp/email"),
            Headers =
            {
                { "accept", "application/json" },
                { "api-key", _settings.ApiKey },
            },
            Content = content
        };

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode(); 

        return response.Content.ReadAsStringAsync().Result;
    }

    

    //write get account function
    public async Task<string> GetAccountAsync()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.brevo.com/v3/account"),
            Headers =
            {
                { "accept", "application/json" },
                { "api-key", _settings.ApiKey },
            },
        };

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    private async Task<EmailDto> BuildEmail(string toEmail, string subject, string htmlBody)
    {
        return new EmailDto
        {
            Sender = new Sender
            {
                Name = _settings.FromName,
                Email = _settings.FromEmail
            },
            To = new List<Recipient>
           {
               new Recipient
               {
                   Email = toEmail,
                   Name = toEmail // Optional: or extract name if available  
               }
           },
            Subject = subject,
            HtmlContent = htmlBody,
            Headers = new Dictionary<string, string> { { "newKey", "New Value" } } // Add any custom headers if needed
        };
    }
}








public class EmailDto
{
    [JsonProperty("sender")]
    public Sender Sender { get; set; }

    [JsonProperty("headers")]
    public Dictionary<string, string> Headers { get; set; }

    [JsonProperty("to")]
    public List<Recipient> To { get; set; }

    [JsonProperty("htmlContent")]
    public string HtmlContent { get; set; }

    [JsonProperty("textContent")]
    public string TextContent { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }
}

public class Sender
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}

public class Recipient
{
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}

