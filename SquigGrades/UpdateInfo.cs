using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SquigGrades
{
    public class UpdateInfo
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
        [JsonPropertyName("isPrerelease")]
        public bool IsPrerelease { get; set; }
    }


}
