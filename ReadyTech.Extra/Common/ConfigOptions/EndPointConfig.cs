using System.ComponentModel.DataAnnotations;

namespace Common.ConfigOptions;

public class EndPointConfig
{
    public const string EndPointSection = "EndPoint";

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public string? WeatherApiKey { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public string? WeatherApiEndPoint { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public string? Latitude { get; set; }


    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public string? Longitude { get; set; }

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public string? Unit { get; set; }
}
