namespace InventoryManagement_Cookie_API
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }


    public class AuthenticationSchema
    {
        public const string DefaultAuthenticationSchema = "InventoryManagement_API";
    }
}