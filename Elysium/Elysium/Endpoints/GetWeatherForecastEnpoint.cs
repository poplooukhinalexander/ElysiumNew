using FastEndpoints;

namespace Elysium.Endpoints
{
    public class GetWeatherForecastEnpoint : EndpointWithoutRequest
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("weatherforecast");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            await SendAsync(result, statusCode: 200, ct); 
        }
    }
}
