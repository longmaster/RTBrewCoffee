using System.ComponentModel.DataAnnotations;

namespace Common.ConfigOptions;
public class ConnectionConfig
{
    public const string CachingSection = "ConnectionStrings";

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public  string? RedisCache { get; set; }
}
