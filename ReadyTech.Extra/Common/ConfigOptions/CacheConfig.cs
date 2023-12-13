using System.ComponentModel.DataAnnotations;

namespace Common.ConfigOptions;
public class CacheConfig
{
    public const string CachingSection = "Cache";

    [Required]
    public double AbsoluteExpireTimeInHours { get; set; }

    [Required]

    public double SlidingExpirationTimeInHours { get; set; }
}
