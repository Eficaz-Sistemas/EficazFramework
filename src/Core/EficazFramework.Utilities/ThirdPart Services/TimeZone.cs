using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EficazFramework.ThirdPart;

public class TimeZone
{
    public static async Task<DateTime> Now(string zone = "America/Sao_Paulo")
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri("http://api.timezonedb.com/")
        };
        try
        {
            string way = string.Format("v2/get-time-zone?key=VWB00DPMYEQH&format=json&by=zone&zone={0}", zone);
            var response = await client.GetAsync(way);
            if (response.IsSuccessStatusCode)
            {
                string response_string = await response.Content.ReadAsStringAsync();
                if (response_string == "null")
                    return DateTime.Now;
                var result_data = JsonSerializer.Deserialize<TimeZoneData>(response_string);
                DateTime dt = DateTime.Now;
                if (result_data != null) { dt = result_data.FormattedDateTime; }
                return dt;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return DateTime.Now;
    }
}

public class TimeZoneData
{
    [ExcludeFromCodeCoverage]
    public string Status { get; set; }
    public string Formatted { get; set; }

    [System.Text.Json.Serialization.JsonIgnore()]
    public DateTime FormattedDateTime
    {
        get
        {
            if (string.IsNullOrEmpty(Formatted))
                return DateTime.Now;
            return DateTime.Parse(Formatted);
        }
    }

    [ExcludeFromCodeCoverage]
    public int Timestamp { get; set; }
}
