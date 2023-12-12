using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ConfigOptions;
public class ConnectionConfig
{
    public const string CachingSection = "ConnectionStrings";

    [Required(AllowEmptyStrings = false)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [MinLength(1)]
    public  string RedisCache { get; set; }
}
